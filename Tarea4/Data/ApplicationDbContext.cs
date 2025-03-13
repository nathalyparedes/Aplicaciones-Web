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
        
        public DbSet<Pez> Peces { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<PezHabitacion> PecesHabitaciones { get; set; }
        public DbSet<Alimento> Alimentos { get; set; }
        public DbSet<Alimentacion> Alimentaciones { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUser>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(450);
            });
            
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityRole>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(450);
            });
            
            // Configurar la clave primaria compuesta de PezHabitacion
            modelBuilder.Entity<PezHabitacion>()
                .HasKey(ph => new { ph.IdPez, ph.IdHabitacion });
            
            // Configurar las relaciones
            modelBuilder.Entity<PezHabitacion>()
                .HasOne(ph => ph.Pez)
                .WithMany(p => p.PecesHabitaciones)
                .HasForeignKey(ph => ph.IdPez)
                .OnDelete(DeleteBehavior.Cascade);
                
            modelBuilder.Entity<PezHabitacion>()
                .HasOne(ph => ph.Habitacion)
                .WithMany(h => h.PecesHabitaciones)
                .HasForeignKey(ph => ph.IdHabitacion)
                .OnDelete(DeleteBehavior.Cascade);
                
            modelBuilder.Entity<Alimentacion>()
                .HasOne(a => a.Pez)
                .WithMany(p => p.Alimentaciones)
                .HasForeignKey(a => a.IdPez)
                .OnDelete(DeleteBehavior.Cascade);
                
            modelBuilder.Entity<Alimentacion>()
                .HasOne(a => a.Alimento)
                .WithMany(al => al.Alimentaciones)
                .HasForeignKey(a => a.IdAlimento)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}