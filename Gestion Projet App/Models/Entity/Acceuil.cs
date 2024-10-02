namespace Gestion_Projet_App.Models.Entity
{
    public class Acceuil
    {
        public int TotalCollaborateur { get; set; }
        public int TotalCollaborateurActive { get; set; }
        public int TotalCollaborateurnInactive { get; set; }
        public int TotalProjet { get; set; }
        public int TotalEquipe { get; set; }
        public int TotalClient { get; set; }
        public int TotalProjetTerminer {get;set;} 
        public int TotalProjetEncour {get;set;} 
        public int TotalProjetAnuller {get;set; }
        public int? TotalProjetEnRetard { get; set; }
        public int? TotalChefProjetEncours { get; set; }
        public int? TotalChefProjet { get; set; }
    }
}
