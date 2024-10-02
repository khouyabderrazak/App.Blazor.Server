using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models;
using Microsoft.AspNetCore.Components;

namespace Gestion_Projet_App.Pages.GestionEquipes
{
    public partial class DetailEquipe
    {
        [Inject]
        private IEquipeService _service { get; set; }

        [Parameter]
        public int id { get; set; }

        public Equipe equipe { get; set; } = new Equipe();

        protected override async Task OnInitializedAsync()
        {
            await GetProjet();

            base.OnInitializedAsync();
        }

        private async Task GetProjet()
        {
            equipe = await _service.Single(id);
        }
    }
}
