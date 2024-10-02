using Gestion_Projet_App.Models.outher;
using System.Collections.ObjectModel;

namespace Gestion_Projet_App.Models.Dto.Taches
{
    public class TacheItem
    {
        public ObservableCollection<Tache> list { get; set; }
        public TacheStatus TacheStatus { get; set; }
    }
}
