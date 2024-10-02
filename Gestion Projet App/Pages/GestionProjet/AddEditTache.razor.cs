using AutoMapper;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models;
using Microsoft.AspNetCore.Components;
using Gestion_Projet_App.Models.Dto.Taches;
using Gestion_Projet_App.Models.outher;

namespace Gestion_Projet_App.Pages.GestionProjet
{
    public partial class AddEditTache
    {
        public TacheDto? tacheDto { get; set; }

        [Parameter]
        public Tache? tache { get; set; }

        [Parameter]
        public TacheStatus? tacheStatus { get; set; }


        [Parameter]
        public int? ProjetId { get; set; }

        [Inject]
        private ITacheService _service { get; set; }

        [Inject]
        private IMapper _mapper { get; set; }

        [Parameter]
        public EventCallback<TacheStatus?> onItemChange { get; set; }

        protected override async Task OnInitializedAsync()
        {
           
            tacheDto = _mapper.Map<TacheDto>(tache);

            if (tacheDto == null)
            {
                tacheDto = new TacheDto();

            }

            await base.OnInitializedAsync();
        }

        public async Task Submit()
        {
            if (tacheStatus != null)
            {
                tacheDto.Statut = tacheStatus;
                tacheDto.ProjetId = ProjetId;
            }

            ICollection<TacheCollaborateur> tacheCollaborateurs = new List<TacheCollaborateur>(); 
            TacheDto tDTo= await _service.Save(tacheDto);
            await onItemChange.InvokeAsync(tDTo.Statut);

        }
    }
}
