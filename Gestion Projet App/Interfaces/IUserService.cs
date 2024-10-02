using Gestion_Projet_App.Models.Entity;
using System.Security.Claims;

namespace Gestion_Projet_App.Interfaces
{
    public interface IUserService
    {
        bool IsUserChefDeProjet(ClaimsPrincipal user, string? ManagerId);
    }
}
