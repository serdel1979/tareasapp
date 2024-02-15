using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TareasAsp.Models.Entidades;

namespace TareasAsp
{
    //public class ApplicationDbContext : DbContext   //<-- esto es si no usamos identity
    public class ApplicationDbContext : IdentityDbContext //<-- herada del sistema de usuarios de identity
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Tarea> Tareas { get; set; }

        public DbSet<Paso> Pasos { get; set; }
        public DbSet<ArchivoAdjunto> ArchivoAdjuntos { get; set; }



    }
}
