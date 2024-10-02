using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto.Projet;

namespace Gestion_Projet_App.Interfaces
{
    public interface IProjetService
    {
        Task Save(ProjetDto request);
        Task<bool> Delete(int id);
        Task<List<Projet>> Search(SearchProjetDto request);
        Task<List<Projet>> All();

        Task<Projet> Single(int id);

        Task OnLancer(int ProjetId);
        Task OnAnnuler(int ProjetId);
        Task OnDelancer(int ProjetId);
        Task OnValider(int ProjetId);
        Task OnInvalider(int ProjetId);

        Task OnReCree(int ProjetId);
    }
}
