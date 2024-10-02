using AutoMapper;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto.EquipeCollaborateur;
using Gestion_Projet_App.Models.Entity;
using Microsoft.AspNetCore.Components;

namespace Gestion_Projet_App.Pages.GestionEquipes
{
    public partial class AddEditEquipeCollaborateur
    {
        public EquipeCollaborateurDto? equipeCollaborateurDto { get; set; }



        [Inject]
        private IEquipeCollaborateurService _service { get; set; }


        [Inject]
        private ICollaborateurService collaborateurService { get; set; }
        public List<ApplicationUser> collaborateurs { get; set; }

        [Inject]
        private IMapper _mapper { get; set; }

        [Parameter]
        public EventCallback onItemChange { get; set; }

        [Parameter]

        public int EquipeId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            equipeCollaborateurDto = new EquipeCollaborateurDto();

            collaborateurs = await collaborateurService.All();
            collaborateurs = collaborateurs.Where(p => !p.EquipeCollaborateurs.Any(ep => ep.EquipeId == EquipeId)).ToList();

            await base.OnInitializedAsync();
        }

        protected override Task OnParametersSetAsync()
        {
            equipeCollaborateurDto = new EquipeCollaborateurDto();
            equipeCollaborateurDto.EquipeId = EquipeId; 
            return base.OnParametersSetAsync();
        }

        public async Task Submit()
        {
            await _service.Save(equipeCollaborateurDto);
            await onItemChange.InvokeAsync();
        }
    }
}
