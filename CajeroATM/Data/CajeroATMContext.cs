using CajeroATM.Models;
using Microsoft.EntityFrameworkCore;

namespace CajeroATM.Data
{
    public class CajeroATMContext : DbContext
    {
        public CajeroATMContext(DbContextOptions<CajeroATMContext> options) : base(options)
        {
        }

        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Operacion> Operaciones { get; set; }
    }
}
