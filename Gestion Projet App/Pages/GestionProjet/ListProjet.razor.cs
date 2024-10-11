using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models.Dto.Projet;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Services;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Gestion_Projet_App.Pages.GestionProjet
{
    public  partial class ListProjet
    {
        [Inject]
        private NavigationManager? _navigationManager { get; set; }

        [Inject]
        private IProjetService _service { get; set; }

        List<Projet> projets;

        public Projet? projetChange { get; set; }

        public string? title { get; set; }

        bool dialogIsOpen = false;

        public SearchProjetDto SearchProjetDto { get; set; }


        private RadzenDataGrid<Projet> dataGrid;
        public int count { get; set; }

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
                // return claimsPrincipal that descripe the current User.
                user = authState?.User;

            }

            SearchProjetDto = new SearchProjetDto();
            await base.OnInitializedAsync();

        }

        


        public async Task onItemChange()
        {
            await dataGrid.Reload();
            projetChange = null;
            dialogIsOpen = false;

        }

        public async Task onDelete(int id)
        {
            await _service.Delete(id);
            await dataGrid.Reload();

        }

        public async Task getAll(LoadDataArgs args)
        {
            projets = await _service.Search(SearchProjetDto);

            if (!user.IsInRole("Admin"))
            {
               var idUser = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
               projets = projets.Where(p =>
               p.ManagerID == idUser  ||
               p.ProjetEquipes.Any(pe => pe.Equipe.ChefId == idUser ) ||
               p.ProjetEquipes.Any(pe =>  pe.Equipe.EquipeCollaborateurs.Any(pec => pec.CollaborateurId == idUser))).ToList();
            }
            
            count = projets.Count;
            projets = projets.Skip(args.Skip.Value).Take(args.Top.Value).ToList();
        }

        public async Task onUpdate(Projet col)
        {
            title = "modifier Projet";
            projetChange = col;
            dialogIsOpen = true;
        }
        public void SelectionChangedEvent(object row)
        {
            //this.StateHasChanged();
        }

        void onAjouter()
        {
            title = "Ajouter Projet";
            dialogIsOpen = true;
        }



        async Task onSearch()
        {
            await dataGrid.Reload();

        }

        async Task onClearSeatch()
        {
            SearchProjetDto = new SearchProjetDto();
            await dataGrid.Reload();

        }

        async Task onVoirDetails(int id)
        {
            _navigationManager.NavigateTo("/projet/details/" + id);
        }

        async Task onAddEquipe(int id)
        {
            _navigationManager.NavigateTo("/projet/projetEquipes/" + id);

        }

    }
}
