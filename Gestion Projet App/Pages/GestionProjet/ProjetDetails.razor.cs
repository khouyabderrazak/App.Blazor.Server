
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto.Projet;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Gestion_Projet_App.Pages.GestionProjet
{
    public partial class ProjetDetails
    {
        [Inject]
        private IProjetService _service { get; set; }
       
        [Parameter]
        public int id { get; set; }

        public Projet projet { get; set; } = new Projet();

        [Inject]
        public IUserService _userService { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }
        ClaimsPrincipal user = null;

        protected override async Task OnInitializedAsync()
        {
            if (authenticationState is not null)
            {
                var authState = await authenticationState;
                user = authState?.User;

            }

            await GetProjet();
            
            base.OnInitializedAsync();
        }

        private async Task GetProjet()
        {
            projet = await _service.Single(id);
        }

        async Task lancer()
        {
            await _service.OnLancer(id);
            await GetProjet();
        }

        async Task delancer()
        {
            await _service.OnDelancer(id);
            await GetProjet();


        }
        async Task valider()
        {
            await _service.OnValider(id);
            await GetProjet();

        }
        async Task invalider()
        {
            await _service.OnInvalider(id);
            await GetProjet();

        }
        async Task annuler()
        {
            await _service.OnAnnuler(id);
            await GetProjet();

        }

        async Task Repris()
        {
            await _service.OnReCree(id);
            await GetProjet();
        }
    }
}
