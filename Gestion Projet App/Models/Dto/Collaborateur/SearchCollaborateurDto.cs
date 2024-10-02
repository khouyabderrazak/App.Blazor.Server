namespace Gestion_Projet_App.Models.Dto
{
    public class SearchCollaborateurDto
    { 
        public string? LastName { get; set; }
        public string? FirstName { get; set; }

        public bool? Active { get; set; } 
    }
}
