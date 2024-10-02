using Gestion_Projet_App.Models.Dto;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Entity;
using Gestion_Projet_App.Models.Dto.Client;

namespace Gestion_Projet_App.Interfaces
{
    public interface IClientService
    {
        Task Save(ClientDto request);
        Task<bool> Delete(int id);
        Task<List<Client>> Search(SearchClientDto request);
        Task<List<Client>> All();
    }
}
