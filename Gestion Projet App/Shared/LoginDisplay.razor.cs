using Gestion_Projet_App.Areas.Identity.Pages.Account;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace Gestion_Projet_App.Shared
{
    public partial class LoginDisplay
    {
       
    
        
        [Inject]
        private  IMatDialogService _matDialogService { get; set; }

        [Inject] NavigationManager _manger { get; set; }


        async Task logout()
        {
            bool res = await _matDialogService.ConfirmAsync("Êtes-vous sûr de vouloir deconnecter ?");
            if (res)
                 _manger.NavigateTo("/logout" , forceLoad: true);
            }
        }
    }

