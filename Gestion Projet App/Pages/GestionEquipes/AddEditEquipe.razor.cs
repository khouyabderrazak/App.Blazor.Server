using AutoMapper;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto.Client;
using Gestion_Projet_App.Models.Dto.Equipe;
using Gestion_Projet_App.Models.Entity;
using Microsoft.AspNetCore.Components;

namespace Gestion_Projet_App.Pages.GestionEquipes
{
    public partial class AddEditEquipe
    {
        public EquipeDto? equipeDto { get; set; }

        [Parameter]
        public Equipe? equipe { get; set; }

        [Inject]
        private IEquipeService _service { get; set; }


        [Inject]
        private ICollaborateurService collaborateurService { get; set; }
        public List<ApplicationUser> collaborateurs { get; set; }
 
        [Inject]
        private IMapper _mapper { get; set; }

        [Parameter]
        public EventCallback onItemChange { get; set; }

        protected override async Task OnInitializedAsync()
        {
            equipeDto = _mapper.Map<EquipeDto>(equipe);

            if (equipeDto == null)
            {
                equipeDto = new EquipeDto();

            }

            collaborateurs = await collaborateurService.All();

            await base.OnInitializedAsync();
        }

        public async Task Submit()
        {
            await _service.Save(equipeDto);
            await onItemChange.InvokeAsync();
        }
    }
}
