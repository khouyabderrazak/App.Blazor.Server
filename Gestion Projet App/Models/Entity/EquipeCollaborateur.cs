using Gestion_Projet_App.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Projet_App.Models
{
    public class EquipeCollaborateur : ModelBase
    {
        public int EquipeId { get; set; }
        [ForeignKey(nameof(EquipeId))]
        public Equipe? Equipe { get; set; }

        public string? CollaborateurId { get; set; }
        [ForeignKey(nameof(CollaborateurId))]
        public ApplicationUser? Collaborateur { get; set; }
    }

}
