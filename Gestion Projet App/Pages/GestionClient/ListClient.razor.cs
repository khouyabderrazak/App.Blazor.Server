using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models.Dto.Client;
using Gestion_Projet_App.Models.Entity;
using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace Gestion_Projet_App.Pages.GestionClient
{
    public partial class ListClient
    {
        [Inject]
        private IClientService _service { get; set; }

        List<Client> clients;

        public Client? clientChange { get; set; }

        public string? title { get; set; }

        bool dialogIsOpen = false;

        public SearchClientDto searchClientDto { get; set; }

        public int count { get; set; }

        private RadzenDataGrid<Client> dataGrid;

        protected override async Task OnInitializedAsync()
        {
            searchClientDto = new SearchClientDto();
            base.OnInitializedAsync();
        }

        public async Task onItemChange()
        {
            clientChange = null;
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
            clients = await _service.Search(searchClientDto);
            count = clients.Count;
            clients = clients.Skip(args.Skip.Value).Take(args.Top.Value).ToList();
        }

        public async Task onUpdate(Client col)
        {
            title = "modifier client";
            clientChange = col;
            dialogIsOpen = true;
        }


        void onAjouter()
        {
            title = "Ajouter client";
            dialogIsOpen = true;
        }



        async Task onSearch()
        {
            await dataGrid.Reload();

        }

        async Task onClearSeatch()
        {
            searchClientDto = new SearchClientDto();
            await dataGrid.Reload();

        }
    }
}
