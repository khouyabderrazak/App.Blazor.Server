using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models.Dto.Client;
using Gestion_Projet_App.Models.Entity;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto.Equipe;

namespace Gestion_Projet_App.Pages.GestionEquipes
{
    public partial class ListEquipe
    {
        [Inject]
        private IEquipeService _service { get; set; }

        List<Equipe> equipes;

        public Equipe? equipeChange { get; set; }

        [Inject] 
        private NavigationManager _navigationManager { get; set; }
        public string? title { get; set; }

        bool dialogIsOpen = false;

        public SearchEquipeDto searchEquipeDto { get; set; }

        public int count { get; set; }

        private RadzenDataGrid<Equipe> dataGrid;

        protected override async Task OnInitializedAsync()
        {
            searchEquipeDto = new SearchEquipeDto();
            base.OnInitializedAsync();
        }

        public async Task onItemChange()
        {
            equipeChange = null;
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
            equipes = await _service.Search(searchEquipeDto);
            count = equipes.Count;
            equipes = equipes.Skip(args.Skip.Value).Take(args.Top.Value).ToList();
        }

        public async Task onUpdate(Equipe col)
        {
            title = "modifier Equipe";
            equipeChange = col;
            dialogIsOpen = true;
        }


        void onAjouter()
        {
            title = "Ajouter Equipe";
            dialogIsOpen = true;
        }



        async Task onSearch()
        {
            await dataGrid.Reload();

        }

        async Task onClearSeatch()
        {
            searchEquipeDto = new SearchEquipeDto();
            await dataGrid.Reload();

        }
        async Task onVoirDetails(int id)
        {
            _navigationManager.NavigateTo("/equipes/detailEquipe/" + id);
        }
    }
}
