using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto.Taches;

namespace Gestion_Projet_App.Interfaces
{
    public interface ITacheCollaborateursService
    {
        Task Save(TacheCollaborateurDto request);
        Task<List<TacheCollaborateur>> All(int TacheId);
        Task<bool> Delete(string collaborateurId,int tacheId);
    }
}
