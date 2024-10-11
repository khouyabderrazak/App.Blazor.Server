using Gestion_Projet_App.Models.Entity;
using Gestion_Projet_App.Models.outher;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Projet_App.Models
{
    public class Projet : ModelBase
    {
        public string Nom { get; set; }
        public string? Description { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public ProjetStatus? Statut { get; set; } = ProjetStatus.Creation;

        // Relation : Un projet peut avoir plusieurs tâches
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public ICollection<Tache>? Taches { get; set; }

        // Relation : Un projet peut avoir plusieurs dépenses
        public ICollection<Depense>? Depenses { get; set; }
        public decimal? Budget { get; set; }
        public int? ClientID { get; set; }
        [ForeignKey(nameof(ClientID))]
        public Client? Client { get; set; }

        public string? ManagerID { get; set; }
        [ForeignKey(nameof(ManagerID))]
        public ApplicationUser? Manager { get; set; }

        public ICollection<ProjetEquipe>? ProjetEquipes { get; set;}
    }

}
