using Microsoft.EntityFrameworkCore;
using API_Pichincha.Models;

namespace API_Pichincha.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }

    }
}
