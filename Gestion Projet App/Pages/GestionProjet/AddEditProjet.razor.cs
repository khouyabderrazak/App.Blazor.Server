using AutoMapper;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models.Dto;
using Gestion_Projet_App.Models;
using Microsoft.AspNetCore.Components;
using Gestion_Projet_App.Models.Dto.Projet;
using Gestion_Projet_App.Models.Entity;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Gestion_Projet_App.Pages.GestionProjet
{
    public partial class AddEditProjet
    {

        public ProjetDto? projetDto { get; set; }

        [Parameter]
        public Projet? projet { get; set; }

        [Inject]
        private IProjetService _service { get; set; }

        [Inject]
        private ICollaborateurService collaborateurService { get; set; }

        [Inject]
        private IClientService clientService { get; set; }

        [Inject]
        private IMapper _mapper { get; set; }

        [Parameter]
        public EventCallback onItemChange { get; set; }

        List<ApplicationUser> collaborateurs { get; set; }
        List<Client> clients { get; set; }

        [Inject]
        public IUserService _userService { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState>? authenticationState { get; set; }
        ClaimsPrincipal user = null;

        protected override async Task OnInitializedAsync()
        {

            if (authenticationState is not null)
            {
                var authState = await authenticationState;
                user = authState?.User;

            }


            projetDto = _mapper.Map<ProjetDto>(projet);

            if (projetDto == null)
            {
                projetDto = new ProjetDto();
               
                if (!user.IsInRole("Admin"))
                {
                    projetDto.ManagerID = user.FindFirst(ClaimTypes.NameIdentifier).Value;
                }
            }
            
           
            collaborateurs = await collaborateurService.All();
            clients = await clientService.All();
            await base.OnInitializedAsync();
        }

        public async Task Submit()
        {
            await _service.Save(projetDto);
            await onItemChange.InvokeAsync();

        }
    }
}
