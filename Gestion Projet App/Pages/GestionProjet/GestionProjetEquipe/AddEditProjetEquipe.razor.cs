using AutoMapper;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto.Client;
using Gestion_Projet_App.Models.Dto.Projet;
using Gestion_Projet_App.Models.Entity;
using Microsoft.AspNetCore.Components;

namespace Gestion_Projet_App.Pages.GestionProjet.GestionProjetEquipe
{
    public partial class AddEditProjetEquipe
    {
        public ProjetEquipeDto? projetEquipeDto { get; set; }

        [Parameter]
        public int? ProjetId { get; set; }

        [Inject]

        public IEquipeService equipeService { get;set; }

        public IList<Equipe> equipes { get; set; }

        

        [Inject]
        private IProjetEquipeServie _service { get; set; }

        [Parameter]
        public EventCallback onItemChange { get; set; }

        protected override async Task OnInitializedAsync()
        {

             projetEquipeDto = new ProjetEquipeDto();

             equipes = await  equipeService.All();
              
             

             await base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            projetEquipeDto.ProjetId = ProjetId;
            
            equipes = equipes.Where(p =>  !p.ProjetEquipes.Any(p => p.ProjetId == ProjetId)).ToList();
            
            await base.OnParametersSetAsync();
        }


        public async Task Submit()
        {
            await _service.Save(projetEquipeDto);
            await onItemChange.InvokeAsync();
        }
    }
}
