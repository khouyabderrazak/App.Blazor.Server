using AutoMapper;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto.Taches;
using Gestion_Projet_App.Models.outher;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.CodeAnalysis;
using Radzen;
using System.Collections.ObjectModel;
using System.Security.Claims;

namespace Gestion_Projet_App.Pages.GestionProjet
{
    public partial class ListTache
    {
        [Parameter]
        public int Projetid { get; set; }

        ObservableCollection<Tache> TachesCreated = new();
        ObservableCollection<Tache> TachesEncours = new ();
        ObservableCollection<Tache> TachesTermines = new();
        ObservableCollection<Tache> TachesDeployee = new();

        Boolean is_ajouter;

        [Inject]
        private ITacheService _service { get; set; }
        [Inject] 
        private IMapper _mapper { get; set; }

        public List<TacheItem> taches { get; set; } = new List<TacheItem>();


        protected override async Task OnInitializedAsync()
        {

            await base.OnInitializedAsync();

  
        }

        protected override async Task OnParametersSetAsync()
        {
            if(taches.Count==0)
                 await SetTaches();

            await base.OnParametersSetAsync();
        }


        async Task SetTaches()
        {
            var AllTaches = await _service.All(Projetid);
            TachesCreated = new ObservableCollection<Tache>(AllTaches.Where(p => p.Statut == TacheStatus.Creation));
            TachesEncours = new ObservableCollection<Tache>(AllTaches.Where(p => p.Statut == TacheStatus.EnCours));
            TachesTermines = new ObservableCollection<Tache>(AllTaches.Where(p => p.Statut == TacheStatus.Termine));
            TachesDeployee = new ObservableCollection<Tache>(AllTaches.Where(p => p.Statut == TacheStatus.Deployer));

            taches.Add(new TacheItem() { list = TachesCreated, TacheStatus = TacheStatus.Creation });
            taches.Add(new TacheItem() { list = TachesEncours, TacheStatus = TacheStatus.EnCours });
            taches.Add(new TacheItem() { list = TachesTermines, TacheStatus = TacheStatus.Termine });
            taches.Add(new TacheItem() { list = TachesDeployee, TacheStatus = TacheStatus.Deployer });

        }

        Tache draggedItem;
        
        void RowRender(RowRenderEventArgs<Tache> args)
        {
            args.Attributes.Add("title", "Drag row to move it to the other DataGrid");
            args.Attributes.Add("style", "cursor:grab");
            args.Attributes.Add("draggable", "true");
            args.Attributes.Add("ondragstart", EventCallback.Factory.Create<DragEventArgs>(this, () => draggedItem = args.Data));
        }

        async Task Move(List<ObservableCollection<Tache>> source, ObservableCollection<Tache> target,TacheStatus status)
        {
            foreach (var src in source)
            {
                if (src.Contains(draggedItem))
                {
                    src.Remove(draggedItem);
                    break;
                }

            }

            if (!target.Contains(draggedItem))
            {
                target.Add(draggedItem);
                draggedItem.Statut = status;
                await _service.Save(_mapper.Map<TacheDto>(draggedItem));
            }

        }



       List<ObservableCollection<Tache>> getListTaches(List<TacheItem> items,TacheItem item )
       {
            List<ObservableCollection<Tache>> items1 = new List<ObservableCollection<Tache>>();
            foreach(var l in items)
            {  if(l.list != item.list)
                items1.Add(l.list);
            }

            return items1;
        }

        bool dialogIsOpen = false;
        public Tache? tacheChange { get; set; }
        public string? title { get; set; }
        public TacheStatus? tacheStatus { get; set; }

        public async Task onItemChange(TacheStatus? status)
        {
            //await getAll();
            tacheChange = null;
            dialogIsOpen = false;
            tacheStatus = null;
            this.is_ajouter = false;

            switch (status)
            {
                case TacheStatus.Creation:
                     TachesCreated = new ObservableCollection<Tache>(await _service.GetCreatedTache(Projetid));
                    setTacheAfterAddUpdate(status, TachesCreated);
                    break;
                case TacheStatus.EnCours:
                      TachesEncours = new ObservableCollection<Tache>(await _service.GetEncourTache(Projetid));
                    setTacheAfterAddUpdate(status, TachesEncours);
                    break;
                case TacheStatus.Termine:
                      TachesTermines = new ObservableCollection<Tache>(await _service.GetTermineTache(Projetid));
                    setTacheAfterAddUpdate(status, TachesTermines);

                    break;
                case TacheStatus.Deployer:
                    TachesDeployee = new ObservableCollection<Tache>(await _service.GetDeployeeTache(Projetid));
                    setTacheAfterAddUpdate(status, TachesDeployee);
                    break;
            }

            this.StateHasChanged();

        }

        void  setTacheAfterAddUpdate(TacheStatus? status,ObservableCollection<Tache> obTache )
        {
            TacheItem tacheItem = taches.Find(p => p.TacheStatus == status);
            tacheItem.list = obTache;

        }

        public async Task onDelete(int id)
        {
            await _service.Delete(id);
            //await getAll();
        }

        public async Task onUpdate(Tache col)
        {
            title = "modifier Tache";
            tacheChange = col;
            dialogIsOpen = true;
        }
        void onAjouter(TacheStatus _tacheStatus)
        {
            title = "Ajouter Tache";
            tacheStatus = _tacheStatus;
            is_ajouter = true;
        }

    }
}
