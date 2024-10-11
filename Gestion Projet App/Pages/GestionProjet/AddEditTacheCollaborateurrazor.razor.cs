using Elfie.Serialization;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Entity;
using Gestion_Projet_App.Models.outher;
using Microsoft.AspNetCore.Components;
using NuGet.Packaging;

namespace Gestion_Projet_App.Pages.GestionProjet
{
    public partial class AddEditTacheCollaborateurrazor
    {
     
        public TacheCollaborateurDto? tacheCollaborateurDto { get; set; }

        [Inject]
        private ICollaborateurService service { get; set; }
        [Inject]

        private ITacheCollaborateursService? tacheCollaborateursService { get; set; }

        [Inject]
        private ITacheService? tacheService { get; set; } 
        public ICollection<ApplicationUser> collaborateurs { get; set; }

        [Parameter]
        public int? tacheId { get; set; }

        public bool onDelete { get; set; } = false;
        public bool onAjouter { get; set; } = false;

        IList<string> values = new List<string>();
        IList<string> valuesCopy = new List<string>();

        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {

            collaborateurs = await service.AllFromProjetEquipes((int)tacheId);

            List<TacheCollaborateur> tacheCollaborateurs= await  this.tacheCollaborateursService.All((int) tacheId);

            foreach(TacheCollaborateur tacheCol in tacheCollaborateurs)
            {
                  values.Add(tacheCol.CollaborateurId);
            }
            valuesCopy.AddRange(values);

            base.OnParametersSetAsync();
        }

        async Task AddEdit()
        {
            if(values.Count > valuesCopy.Count)
            {
                string collaborateurId = values.Where(p => valuesCopy.IndexOf(p) == -1).First();
                tacheCollaborateurDto = new TacheCollaborateurDto()
            {
                Id=null,
                CollaborateurId = collaborateurId,
                TacheId = (int) tacheId
             };
               await tacheCollaborateursService.Save(tacheCollaborateurDto);
                valuesCopy.Add(collaborateurId);
            }
            else
            {
                string collaborateurId = valuesCopy.Where(p => values.IndexOf(p) == -1).First();
                await tacheCollaborateursService.Delete(collaborateurId,(int) tacheId);
                valuesCopy.Remove(collaborateurId);
            }

          //  onItemChange.InvokeAsync();

        }

        async Task supprimerTache()
        {
            await tacheService.Delete((int) tacheId);
            onDelete = false;
        }

    }
}
