using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models.Dto;
using Gestion_Projet_App.Models;
using Microsoft.AspNetCore.Components;
using Radzen;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Radzen.Blazor;
using Gestion_Projet_App.Models.Entity;

namespace Gestion_Projet_App.Pages.GestionCollaborateur
{
    public partial class ListCollaborateur
    {
        [Inject]
        private ICollaborateurService _service { get; set; }

        List<ApplicationUser> collaborateurs;

        public ApplicationUser? collaborateurChange { get; set; }

        public string? title { get; set; }

        bool dialogIsOpen = false;

        public SearchCollaborateurDto SearchCollaborateurDto { get; set; }

        public int count { get; set; }

        private RadzenDataGrid<ApplicationUser> dataGrid;

        [Inject]
        private NavigationManager navigationManager {get;set;}

        protected override async Task OnInitializedAsync()
        {
            SearchCollaborateurDto = new SearchCollaborateurDto();
            base.OnInitializedAsync();
        }

        public async Task onItemChange()
        {
            collaborateurChange = null;
            dialogIsOpen = false;
            await dataGrid.Reload();
        }

        public async Task onDelete(string id)
        {
            await _service.Delete(id);
            await dataGrid.Reload();

        }

        public async Task getAll(LoadDataArgs args)
        {
            collaborateurs = await _service.Search(SearchCollaborateurDto);
            count = collaborateurs.Count;
            collaborateurs = collaborateurs.Skip(args.Skip.Value).Take(args.Top.Value).ToList();
        }

        public async Task onUpdate(ApplicationUser col)
        {
            title = "modifier collaborateur";
            collaborateurChange = col;
            dialogIsOpen = true;
        }
      

        void onAjouter()
        {
            title = "Ajouter collaborateur";
            dialogIsOpen = true;
        }



        async Task onSearch()
        {
            await dataGrid.Reload();

        }

        async Task onClearSeatch()
        {
            SearchCollaborateurDto = new SearchCollaborateurDto();
            await dataGrid.Reload();

        }

        void onVoirDetails(string id)
        {
             navigationManager.NavigateTo("/collaborateur/details/"+ id);
        }

    }
}
