using Gestion_Projet_App.Models.Dto;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto.Equipe;

namespace Gestion_Projet_App.Interfaces
{
    public interface IEquipeService
    {
        Task Save(EquipeDto request);
        Task<bool> Delete(int id);
        Task<List<Equipe>> Search(SearchEquipeDto request);
        Task<List<Equipe>> All();

        Task<Equipe> Single(int id);
    }
}
