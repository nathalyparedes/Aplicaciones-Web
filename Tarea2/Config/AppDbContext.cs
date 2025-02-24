using Microsoft.EntityFrameworkCore;
using Tarea2.Models;

namespace Tarea2.Config
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<ClienteModel> Clientes { get; set; }
        
    }
}
