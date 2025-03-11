using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaParcial1.Models;


namespace PruebaParcial1.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Autores> Autores { get; set; }
    public DbSet<Libros> Libros { get; set; }
protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la entidad Autor
            modelBuilder.Entity<Autores>()
                .HasKey(a => a.AutorId);

            // Configuración de la entidad Libro
            modelBuilder.Entity<Libros>()
                .HasKey(l => l.LibroId);

            // Configuración de la relación entre Libro y Autor
            modelBuilder.Entity<Libros>()
                .HasOne(l => l.Autor)
                .WithMany(a => a.Libros)
                .HasForeignKey(l => l.AutorId);
        }
    }
