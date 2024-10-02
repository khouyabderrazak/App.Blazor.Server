using Microsoft.AspNetCore.Components;

namespace Gestion_Projet_App.Shared
{
    public partial class SelectButton
    {
        [Parameter]
        public bool? Statut { get; set; } = true;

        [Parameter]
        public EventCallback<bool>  onValueChange {get; set;}    

        void onTrue()
        {
            Statut = true;
            onValueChange.InvokeAsync(true);
        }

        void onFalse()
        {
            Statut = false;
            onValueChange.InvokeAsync(false);
        }

    }
}
