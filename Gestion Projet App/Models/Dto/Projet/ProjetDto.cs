using System.ComponentModel.DataAnnotations;

namespace Gestion_Projet_App.Models.Dto.Projet
{
    public class ProjetDto
    {
        public int? Id { get;set;}
        
        [Required]
        public string Nom { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime DateDebut { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime DateFin { get; set; } = DateTime.UtcNow;
        public decimal? Budget { get; set; }
        public int? ClientID { get; set; }
        public string? ManagerID { get; set; }


    }
}
