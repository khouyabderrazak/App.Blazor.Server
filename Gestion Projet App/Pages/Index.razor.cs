using Gestion_Projet_App.Data;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models.Entity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Security.Claims;

namespace Gestion_Projet_App.Pages
{
    public partial class Index
    {
        public Acceuil acceuil { get; set; }
        
        [Inject]
        private IAcceuilService _service { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }
        ClaimsPrincipal user = null;

        [Inject]
        private IDbContextFactory<Gestion_Projet_AppContext> dbContextFactory { get; set; }

        protected override async Task OnInitializedAsync()
        {

            acceuil = await _service.AllData();

            if (authenticationState is not null)
            {
                var authState = await authenticationState;
                user = authState?.User;
               
            }


             await base.OnInitializedAsync();
        }


    }
}
