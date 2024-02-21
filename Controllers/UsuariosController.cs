using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TareasAsp.Models;

namespace TareasAsp.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext context;

        public UsuariosController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> SigninManager,
            ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.SigninManager = SigninManager;
            this.context = context;
        }

        public SignInManager<IdentityUser> SigninManager { get; }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Registro()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registro(RegistroViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            var usuario = new IdentityUser()
            {
                Email = modelo.Email,
                UserName = modelo.Email
            };

            var resultado = await userManager.CreateAsync(usuario, password: modelo.Password);

            if (resultado.Succeeded)
            {
                await SigninManager.SignInAsync(usuario, isPersistent: true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var err in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
                return View(modelo);
            }

        }


        [AllowAnonymous]
        public IActionResult Login(string mensaje = null)
        {
            if(mensaje is not null)
            {
                ViewData["mensaje"] = mensaje;

            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            var resultado = await SigninManager.PasswordSignInAsync(modelo.Email,
                modelo.Password, modelo.Recordar, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Usuario o clave incorrecto");
                return View(modelo);
            }


        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public ChallengeResult LoginExterno(string proveedor, string urlRetorno = null)
        {
            var urlRedireccion = Url.Action("RegistrarUsuarioExterno",
                values: new { urlRetorno });

            var propiedades = SigninManager.ConfigureExternalAuthenticationProperties(
                proveedor, urlRedireccion);

            return new ChallengeResult(proveedor, propiedades);

        }




        [AllowAnonymous]
        public async Task<IActionResult> RegistrarUsuarioExterno(
          string urlRetorno = null, string remoteError = null)
        {

            urlRetorno = urlRetorno ?? Url.Content("~/");

            var mensaje = "";

            if(remoteError is not null)
            {
                mensaje = $"Error del proveedor externo :{remoteError}";

                return RedirectToAction("login", routeValues: new { mensaje });
            
            }

            var info = await SigninManager.GetExternalLoginInfoAsync();
            if(info is null)
            {
                mensaje = "Error cargando data de login externo";
                return RedirectToAction("login", routeValues: new { mensaje });
            }

            var resultadoLoginExterno = await SigninManager.ExternalLoginSignInAsync(
                info.LoginProvider, info.ProviderKey, isPersistent: true,
                bypassTwoFactor: true);

            //cuenta existe
            if (resultadoLoginExterno.Succeeded)
            {
                return LocalRedirect(urlRetorno);
            }

            //si el usuario no tiene cuenta se crea

            string email = "";

            if(info.Principal.HasClaim(c=>c.Type == ClaimTypes.Email)){
                email = info.Principal.FindFirstValue(ClaimTypes.Email);
            }
            else
            {
                mensaje = "Error leyendo email del proveedor";
                return RedirectToAction("login",routeValues: new { mensaje });  
            }

            var usuario = new IdentityUser
            {
                Email = email,
                UserName = email,
            };

            var resultadoCrearUsuario = await userManager.CreateAsync(usuario);

            if (!resultadoCrearUsuario.Succeeded)
            {
                mensaje = resultadoCrearUsuario.Errors.First().Description;
                return RedirectToAction("login", routeValues: new { mensaje });
            }

            var resultadoAgregarLogin = await userManager.AddLoginAsync(usuario, info);

            if (resultadoAgregarLogin.Succeeded)
            {
                await SigninManager.SignInAsync(usuario, isPersistent: false, info.LoginProvider);
                return LocalRedirect(urlRetorno);
            }

            mensaje = "Ha ocurrido un error";
            return RedirectToAction("login", routeValues: new { mensaje });

        }

        [HttpGet]
        public async Task<IActionResult> Listado(string mensaje = null)
        {
            var usuarios = await context.Users.Select(u => new UsuarioViewModel
            {
                Email = u.Email
            }).ToListAsync();

            var modelo = new UsuarioListadoViewModel();
            modelo.Usuarios = usuarios;
            modelo.Mensaje = mensaje;

            return View(modelo);
        }
    }
}
