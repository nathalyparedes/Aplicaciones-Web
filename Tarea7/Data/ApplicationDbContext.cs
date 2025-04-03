using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tarea7.Models;

namespace Tarea7.Data;

    public class ApplicationDbContext : IdentityDbContext<UsuariosModel>
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

