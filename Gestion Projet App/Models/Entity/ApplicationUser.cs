using Microsoft.AspNetCore.Identity;

namespace Gestion_Projet_App.Models.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public bool Active { get; set; } = false;

        public ICollection<EquipeCollaborateur>? EquipeCollaborateurs { get; set; }
        public ICollection<IdentityUserRole<string>>? UserRoles { get; set; } 

    }
}
