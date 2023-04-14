using CajeroATM.Models;
using Microsoft.EntityFrameworkCore;

namespace CajeroATM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Operacion> Operaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aquí puedes agregar configuraciones adicionales para tus modelos si es necesario
        }
    }
}
