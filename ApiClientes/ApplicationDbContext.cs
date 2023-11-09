using ApiClientes.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiClientes
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
