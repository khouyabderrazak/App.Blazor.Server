using Gestion_Projet_App.Models.outher;
using System.ComponentModel.DataAnnotations;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Entity;
namespace Gestion_Projet_App.Models.Dto.Taches
{
    public class TacheDto
    {
        public int? Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public string? Description { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public int? ProjetId { get; set; }
        public TacheStatus? Statut { get; set; }
        public ICollection<ApplicationUser>? Collaborateurs { get; set; }
    }
}
