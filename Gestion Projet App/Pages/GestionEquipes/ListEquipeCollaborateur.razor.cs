using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models.Dto.Equipe;
using Gestion_Projet_App.Models;
using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;

namespace Gestion_Projet_App.Pages.GestionEquipes
{
    public partial class ListEquipeCollaborateur
    {
        [Parameter]
        public int EquipeId { get; set; }

        [Inject]
        private IEquipeCollaborateurService _service { get; set; }

        List<EquipeCollaborateur> equipeCollaborateurs;

        public EquipeCollaborateur? equipeCollaborateurChange { get; set; }
        public string? title { get; set; }

        bool dialogIsOpen = false;

       

        public int count { get; set; }

        private RadzenDataGrid<EquipeCollaborateur> dataGrid;

        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
        }

        public async Task onItemChange()
        {
            equipeCollaborateurChange = null;
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
            equipeCollaborateurs = await _service.Search(EquipeId);
            count = equipeCollaborateurs.Count;
            equipeCollaborateurs = equipeCollaborateurs.Skip(args.Skip.Value).Take(args.Top.Value).ToList();
        }


        void onAjouter()
        {
            title = "Ajouter Collaborateur";
            dialogIsOpen = true;
        }


    }
}
