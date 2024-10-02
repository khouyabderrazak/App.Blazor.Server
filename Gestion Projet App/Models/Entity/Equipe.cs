using Gestion_Projet_App.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Projet_App.Models
{
    public class Equipe : ModelBase
    {
        public string Nom { get; set; }

        // Relation : Une équipe peut avoir plusieurs collaborateurs
        public string? ChefId { get; set; }
        [ForeignKey(nameof(ChefId))]
        public ApplicationUser? Chef { get; set; }
        public ICollection<EquipeCollaborateur> EquipeCollaborateurs { get; set; }
        public ICollection<ProjetEquipe>? ProjetEquipes { get; set; }

    }

}
