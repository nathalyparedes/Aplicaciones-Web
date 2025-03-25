using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tarea5.Models;

namespace Tarea5.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
        public DbSet<ProveedoresModel> Proveedores { get; set; }
        public DbSet<ProductoModel> Productos { get; set; }
        public DbSet<StockModel> Stocks { get; set; }

        public DbSet<ClientesModel> Clientes { get; set; }
        public DbSet<FacturaModel> Facturas { get; set; }
        public DbSet<DetalleFacturaModel> DetalleFactura { get; set; }
}
