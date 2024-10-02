using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models.Dto.Client;
using Gestion_Projet_App.Models.Entity;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;

namespace Gestion_Projet_App.Pages.GestionProjet.GestionProjetEquipe
{
    public partial class ListProjetEquipe
    {
        [Inject]
        private IProjetEquipeServie _service { get; set; }

        List<ProjetEquipe> projetEquipes;

        public ProjetEquipe? projetEquipeChange { get; set; }

        public string? title { get; set; }

        bool dialogIsOpen = false;

        [Parameter]
        public int ProjetId { get; set; }

        [Inject]
        public NavigationManager _navigationManager { get; set; }
        public int count { get; set; }

        private RadzenDataGrid<ProjetEquipe> dataGrid;

        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
        }

        public async Task onItemChange()
        {
            projetEquipeChange = null;
            dialogIsOpen = false;
            await dataGrid.Reload();
        }

        public async Task onDelete(int id)
        {
            await _service.Delete(id);
            await dataGrid.Reload();

        }

        public async Task getAll(LoadDataArgs args)
        {
            projetEquipes = await _service.All(ProjetId);
            count = projetEquipes.Count;
            projetEquipes = projetEquipes.Skip(args.Skip.Value).Take(args.Top.Value).ToList();
        }

        public async Task onUpdate(ProjetEquipe col)
        {
            title = "projet equipe client";
            projetEquipeChange = col;
            dialogIsOpen = true;
        }


        void onAjouter()
        {
            title = "Ajouter projet equipe";
            dialogIsOpen = true;
        }
        async Task onVoirDetails(int id)
        {
            _navigationManager.NavigateTo("/equipes/detailEquipe/" + id);
        }

    }
}
