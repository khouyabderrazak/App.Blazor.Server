using AutoMapper;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models.Dto.Equipe;
using Gestion_Projet_App.Models.Entity;
using Gestion_Projet_App.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Gestion_Projet_App.Data;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Projet_App.Pages.GestionCollaborateur.GestionRoles
{
    public partial class AddEditUserRole
    {

        [Parameter]
        public ApplicationUser User { get; set; }

        [Parameter]
        public EventCallback onItemChange { get; set; }

        [Inject]
        private UserManager<ApplicationUser> _userManager { get; set; }
        [Inject]
        private RoleManager<IdentityRole> _roleManager { get; set; }

        private List<IdentityRole> roles { get; set; }

        public RoleAdd role  {get;set;}

        protected override async Task OnInitializedAsync()
        {
            role = new RoleAdd();
            roles = await  _roleManager.Roles.ToListAsync();
            await base.OnInitializedAsync();
        }

        public async Task Submit()
        {
            ApplicationUser user = await _userManager.FindByIdAsync(User.Id);
            await _userManager.AddToRoleAsync(user,role.roleName);
            await onItemChange.InvokeAsync();
        }

    }
    public class RoleAdd
    {
         [Required]
         public string roleName { get; set; }
    }

}
