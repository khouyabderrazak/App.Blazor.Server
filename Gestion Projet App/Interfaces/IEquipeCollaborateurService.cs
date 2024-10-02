using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto.EquipeCollaborateur;

namespace Gestion_Projet_App.Interfaces
{
    public interface IEquipeCollaborateurService
    {
        Task Save(EquipeCollaborateurDto request);
        Task<bool> Delete(int id);
        Task<List<EquipeCollaborateur>> Search(int EquipeId);
    }
}
