using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Projet_App.Models
{
    public class TacheCollaborateurDto
    {
        public int? Id { get; set; }
        [Required]
        public int TacheId { get; set; }
        [Required]
        public string CollaborateurId { get; set; }
    }
}
