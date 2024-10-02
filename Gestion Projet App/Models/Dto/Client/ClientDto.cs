using System.ComponentModel.DataAnnotations;

namespace Gestion_Projet_App.Models.Dto.Client
{
    public class ClientDto
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Email { get; set; }
        
        [Required]
        public string Phone { get; set; }
        
        [Required]
        public string Address { get; set; }
    }
}
