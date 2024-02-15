using System.ComponentModel.DataAnnotations;

namespace TareasAsp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El campo {0} debe ser un Email válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Password { get; set; }
        [Display(Name ="Recuérdame")]
        public bool Recordar { get; set; }

    }
}
