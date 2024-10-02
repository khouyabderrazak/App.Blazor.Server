using AutoMapper;
using Gestion_Projet_App.Interfaces;
using Microsoft.AspNetCore.Components;
using Gestion_Projet_App.Models.Dto.Client;
using Gestion_Projet_App.Models.Entity;

namespace Gestion_Projet_App.Pages.GestionClient
{
    public partial class AddEditClient
    {
        public ClientDto? clientDto { get; set; }

        [Parameter]
        public Client? client { get; set; }

        [Inject]
        private IClientService _service { get; set; }

        [Inject]
        private IMapper _mapper { get; set; }

        [Parameter]
        public EventCallback onItemChange { get; set; }

        protected override Task OnInitializedAsync()
        {
            clientDto = _mapper.Map<ClientDto>(client);

            if (clientDto == null)
            {
                clientDto = new ClientDto();

            }

            return base.OnInitializedAsync();
        }

        public async Task Submit()
        {
            await _service.Save(clientDto);
            await onItemChange.InvokeAsync();
        }
    }
}
