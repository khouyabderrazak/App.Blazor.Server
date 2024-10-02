using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;
using Microsoft.AspNetCore.Identity;
using Gestion_Projet_App.Models.Entity;
using MatBlazor;
using Gestion_Projet_App.Data;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Projet_App.Pages.GestionCollaborateur.GestionRoles
{
    public partial class ListUserRoles
    {
        [Parameter]
        public ApplicationUser User { get; set; }

        [Inject]
        private UserManager<ApplicationUser> _userManager { get; set; }
        [Inject]
        private RoleManager<IdentityRole> _roleManager { get; set; }

        [Inject]
        private IMatToaster _toaster { get; set; }

        [Inject]
        private IMatDialogService _matDialogService { get; set; }

        private IList<Item> userRoles { get; set; }

        public string? title { get; set; }

        bool dialogIsOpen = false;

        public int count { get; set; }

        private RadzenDataGrid<Item> dataGrid;

        protected override async Task OnInitializedAsync()
        {
            
            await base.OnInitializedAsync();
        }

        private async Task LoadUserRolesAsync()
        {
            try
            {
                var allRoles = await _userManager.GetRolesAsync(User);
                userRoles = allRoles.Select((role, index) => new Item { id = index + 1, roleName = role }).ToList();
                count = userRoles.Count;
            }
            catch (Exception ex)
            {
                _toaster.Add("Erreur lors du chargement des rôles : " + ex.Message, MatToastType.Danger);
            }
        }

        public async Task onItemChange()
        {
            dialogIsOpen = false;
            await LoadUserRolesAsync(); // Reloading roles
            await dataGrid.Reload();
        }

        public async Task onDelete(string roleName)
        {
            bool confirm = await _matDialogService.ConfirmAsync("Êtes-vous sûr de vouloir supprimer ce rôle ?");
            if (confirm)
            {
                
                        ApplicationUser user = await _userManager.FindByIdAsync(User.Id);
                        await  _userManager.RemoveFromRoleAsync(user, roleName);
                        _toaster.Add("Rôle supprimé avec succès", MatToastType.Success);
                        await dataGrid.Reload();

            }
        }

        public async Task getAll(LoadDataArgs args)
        {
            await LoadUserRolesAsync();

            var skip = args.Skip ?? 0;
            var top = args.Top ?? count;

            userRoles = userRoles.Skip(skip).Take(top).ToList();
        }

        void onAjouter()
        {
            title = "Ajouter Role";
            dialogIsOpen = true;
        }
    }

    class Item
    {
        public int id { get; set; }
        public string roleName { get; set; }
    }
}
