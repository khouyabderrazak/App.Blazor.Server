using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using Gestion_Projet_App.Models.Entity;
using Microsoft.AspNetCore.Identity;

namespace Gestion_Projet_App.Pages.GestionCollaborateur
{
    public partial class CollaborateurDetails
    {
        [Inject]
        private ICollaborateurService _service { get; set; }

        [Inject]

        private UserManager<ApplicationUser> UserManager { get; set; }

        [Parameter]
        public string id { get; set; }

        public ApplicationUser user { get; set; } = new ApplicationUser();

        protected override async Task OnInitializedAsync()
        {
            await GetUser();

            base.OnInitializedAsync();
        }

        private async Task GetUser()
        {
            user = await _service.Single(id);
        }
    }
}
