using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto.Projet;
using Gestion_Projet_App.Models.Entity;

namespace Gestion_Projet_App.Interfaces
{
    public interface IProjetEquipeServie
    {
        Task Save(ProjetEquipeDto request);
        Task<List<ProjetEquipe>> All(int ProjetId);
        Task<bool> Delete(int ProjetEquipeId );
    }
}
