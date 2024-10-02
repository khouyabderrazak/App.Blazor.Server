using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Projet_App.Models.Dto.EquipeCollaborateur
{
    public class EquipeCollaborateurDto
    {
        public int? Id {get;set;}
        [Required]
        public int EquipeId { get; set; }
        [Required]
        public string? CollaborateurId { get; set; }
    }
}
