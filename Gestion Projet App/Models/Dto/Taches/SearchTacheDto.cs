namespace Gestion_Projet_App.Models.Dto.Taches
{
    public class SearchTacheDto
    {
        public string? Nom { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public int? ProjetId { get; set; }
    }
}
