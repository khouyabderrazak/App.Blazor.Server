using Gestion_Projet_App.Models.Dto.Projet;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto.Taches;
using Gestion_Projet_App.Models.outher;

namespace Gestion_Projet_App.Interfaces
{
    public interface ITacheService
    {
        Task<TacheDto> Save(TacheDto request);
        Task<bool> Delete(int id);
        Task<List<Tache>> GetCreatedTache(int ProjetId);
        Task<List<Tache>> GetEncourTache(int ProjetId);
        Task<List<Tache>> GetTermineTache(int ProjetId);
        Task<List<Tache>> GetDeployeeTache(int ProjetId);
        Task<List<Tache>> All(int ProjetId);

    }
}
