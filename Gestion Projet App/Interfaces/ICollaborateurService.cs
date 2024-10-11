using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto;
using Gestion_Projet_App.Models.Entity;

namespace Gestion_Projet_App.Interfaces
{
    public interface ICollaborateurService
    {
        Task Save(ApplicationUser request);
        Task<bool> Delete(string id);
        Task<List<ApplicationUser>>  Search(SearchCollaborateurDto request);
        Task<List<ApplicationUser>> All();
        Task<ApplicationUser> Single(string id);
        Task<List<ApplicationUser>> AllFromProjetEquipes(int tacheId);
     }
}
