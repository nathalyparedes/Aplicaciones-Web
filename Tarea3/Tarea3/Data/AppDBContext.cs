using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tarea3.Models;

namespace Tarea3.Data
{
    public class AppDBContext : DbContext
    {
               public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {}


        public DbSet<Tarea3.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<Tarea3.Models.Plan> Plan { get; set; } = default!;
        public DbSet<Tarea3.Models.Pago> Pago { get; set; } = default!;
        public DbSet<Tarea3.Models.Membresia> Membresia { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Plan>().ToTable("Plan");
            modelBuilder.Entity<Pago>().ToTable("Pago");
            modelBuilder.Entity<Membresia>().ToTable("Membresia");
        }
    }
}
