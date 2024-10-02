using Gestion_Projet_App.Models.Entity;
using Gestion_Projet_App.Models.outher;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Projet_App.Models
{
    public class Tache : ModelBase
    {
        public string Nom { get; set; }
        public string? Description { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public TacheStatus? Statut { get; set; }

        public int? ProjetId { get; set; }
        [ForeignKey(nameof(ProjetId))]
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public Projet? Projet { get; set; }

        public ICollection<TacheCollaborateur>? TacheCollaborateurs { get; set; }
      
    }

}
