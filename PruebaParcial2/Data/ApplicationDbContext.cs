using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaParcial2.Models;
namespace PruebaParcial2.Data;

    public class ApplicationDbContext : IdentityDbContext<UsuariosModel>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Participante> Participantes { get; set; }
    public DbSet<Organizador> Organizadores { get; set; }
    public DbSet<Lugar> Lugares { get; set; }
    public DbSet<EventoParticipante> EventoParticipantes { get; set; }
    public DbSet<EventoOrganizador> EventoOrganizadores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.EnableSensitiveDataLogging();
}

}
