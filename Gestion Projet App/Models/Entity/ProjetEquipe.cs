using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Projet_App.Models.Entity
{
    public class ProjetEquipe : ModelBase
    {
          public int? EquipeId { get; set; }
          [ForeignKey(nameof(EquipeId))]
          public Equipe? Equipe { get; set; }

          public int? ProjetId { get; set; }
          [ForeignKey(nameof(ProjetId))]
          public Projet? Projet { get; set; }

    }
}
