using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Projet_App.Data;

public class Gestion_Projet_AppContext : IdentityDbContext<ApplicationUser>
{
    public Gestion_Projet_AppContext(DbContextOptions<Gestion_Projet_AppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationUser> Collaborateurs { get; set; }
    public virtual DbSet<Projet> Projets { get; set; }
    public virtual DbSet<Tache> Taches { get; set; }
    public virtual DbSet<Depense> Depenses { get; set; }
    public virtual DbSet<Equipe> Equipes { get; set; }
    public virtual DbSet<EquipeCollaborateur> EquipeCollaborateurs { get; set; }
    public virtual DbSet<TacheCollaborateur> TacheCollaborateurs { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<ProjetEquipe> ProjetEquipes { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<Projet>()
      .HasMany(e => e.Taches)
      .WithOne(e => e.Projet)
      .HasForeignKey(e => e.ProjetId)
      .OnDelete(DeleteBehavior.Cascade);

    }
}
