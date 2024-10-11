using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using Gestion_Projet_App.Models.Entity;
using Microsoft.AspNetCore.Identity;
using MatBlazor;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Projet_App.Pages
{
    public partial class Profile
    {
        [Inject]
        private IMatToaster _toaster { get; set; }
        [Inject]
        private  IMatDialogService _matDialogService { get; set;}

        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }
        ClaimsPrincipal user = null;

        public ApplicationUser Input { get; set; } = new ApplicationUser();

        [Inject]
        public UserManager<ApplicationUser> userManager { get; set; }

        public string UserId { get; set; }

        public bool onModifier { get; set; } = false;


        protected override async Task OnInitializedAsync()
        {
            if (authenticationState is not null)
            {
                var authState = await authenticationState;
                // return claimsPrincipal that descripe the current User.
                user = authState?.User;
                UserId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Input = await userManager.FindByIdAsync(UserId);
            }
        }

         async Task Submit()
        {
            bool res = await _matDialogService.ConfirmAsync("Êtes-vous sûr de vouloir modifer vos informations ?");
            if (res)
            {
                    await userManager.UpdateAsync(Input);
                     this.onModifier = false;
                    _toaster.Add("modification des information avec success", MatToastType.Success, "Message de succès");
            }
        }

        }
}
