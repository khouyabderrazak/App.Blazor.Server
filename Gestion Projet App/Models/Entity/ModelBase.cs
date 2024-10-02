using System.ComponentModel.DataAnnotations;

namespace Gestion_Projet_App.Models.Entity
{
    public class ModelBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow;
    }
}
