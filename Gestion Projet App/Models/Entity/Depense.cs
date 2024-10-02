using Gestion_Projet_App.Models.Entity;

namespace Gestion_Projet_App.Models
{
    public class Depense : ModelBase
    {
        public string Categorie { get; set; }
        public decimal Montant { get; set; }
        public DateTime Date { get; set; }

        // Foreign Key : Projet
        public int ProjetId { get; set; }
        public Projet Projet { get; set; }
    }

}
