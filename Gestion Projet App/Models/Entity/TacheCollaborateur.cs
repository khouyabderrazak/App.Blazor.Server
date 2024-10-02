using Gestion_Projet_App.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Projet_App.Models
{
    public class TacheCollaborateur : ModelBase
    {
        public int TacheId { get; set; }
        [ForeignKey(nameof(TacheId))]
        public Tache? Tache { get; set; }

        public string CollaborateurId { get; set; }
        [ForeignKey(nameof(CollaborateurId))]
        public ApplicationUser? Collaborateur { get; set; }
    }
}
