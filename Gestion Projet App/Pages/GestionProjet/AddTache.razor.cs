using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models.Dto.Taches;
using Gestion_Projet_App.Models.outher;
using Microsoft.AspNetCore.Components;

namespace Gestion_Projet_App.Pages.GestionProjet
{
    public partial class AddTache
    {
        public TacheDto? tacheDto { get; set; } = new TacheDto();

        [Parameter]
        public TacheStatus? tacheStatus { get; set; }


        [Parameter]
        public int? ProjetId { get; set; }

        [Inject]
        private ITacheService _service { get; set; }

        [Parameter]
        public EventCallback<TacheStatus?> onItemChange { get; set; }





        async Task Submit()
        {

            if (tacheStatus != null)
            {
                tacheDto.Statut = tacheStatus;
                tacheDto.ProjetId = ProjetId;
            }
            TacheDto dto = await _service.Save(tacheDto);
            await onItemChange.InvokeAsync(dto.Statut);
        }
    }
}
