using System.ComponentModel.DataAnnotations;

namespace Gestion_Projet_App.Models.outher
{
    public enum ProjetStatus
    {
        [Display(Name = "Création")]
        Creation,

        [Display(Name = "En cours")]
        EnCours,

        [Display(Name = "Terminé")]
        Termine,

        [Display(Name = "Annulé")]
        Annuler
    }

    public enum TacheStatus
    {
        [Display(Name = "Création")]
        Creation,

        [Display(Name = "En cours")]
        EnCours,

        [Display(Name = "Terminé")]
        Termine,

        [Display(Name = "Déployé")]
        Deployer
    }
}
