using System.ComponentModel.DataAnnotations;

namespace Gestion_Projet_App.Models.Dto.Equipe
{
    public class EquipeDto
    {

        public int? Id { get; set; }
        [Required]
        public string Nom { get; set; }

        // Relation : Une équipe peut avoir plusieurs collaborateurs
        [Required]
        public string ChefId { get; set; }
    }
}
