using Gestion_Projet_App.Data;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Gestion_Projet_App.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
           
        }
        public bool IsUserChefDeProjet(ClaimsPrincipal user, string? ManagerId)
        {
            if (user.IsInRole("Admin"))
            {
                return true;
            }

            if (ManagerId == null)
            {
                return false;
            }
            if (user.FindFirst(ClaimTypes.NameIdentifier)?.Value == ManagerId)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}
