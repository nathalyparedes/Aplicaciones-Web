using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Tarea4.Models;

namespace Tarea4.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    public DbSet<Habitat> Habitats { get; set; }
    public DbSet<Animal> Animales { get; set; }
    public DbSet<Cuidador> Cuidadores { get; set; }
    public DbSet<CuidadorHabitat> CuidadoresHabitats { get; set; }
    public DbSet<Guia> Guias { get; set; }
    public DbSet<Visita> Visitas { get; set; }
        
   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurar clave primaria compuesta para la tabla intermedia
        modelBuilder.Entity<CuidadorHabitat>()
            .HasKey(ch => new { ch.CuidadorId, ch.HabitatId });

        base.OnModelCreating(modelBuilder);
    }
}
}