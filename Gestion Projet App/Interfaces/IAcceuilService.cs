using Gestion_Projet_App.Models.Entity;

namespace Gestion_Projet_App.Interfaces
{
    public interface IAcceuilService
    {
        public Task<Acceuil> AllData();
    }
}
