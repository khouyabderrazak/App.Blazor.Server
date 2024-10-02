using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Projet_App.Models.Dto.Projet
{
    public class ProjetEquipeDto
    {
        public int? Id { get; set; }
        [Required]
        public int? EquipeId { get; set; }
        [Required]
        public int? ProjetId { get; set; }

    }

}
