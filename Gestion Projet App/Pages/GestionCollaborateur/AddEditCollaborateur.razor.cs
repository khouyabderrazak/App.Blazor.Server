using AutoMapper;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models.Dto;
using Gestion_Projet_App.Models;
using Microsoft.AspNetCore.Components;
using Gestion_Projet_App.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Gestion_Projet_App.Areas.Identity.Pages.Account;

namespace Gestion_Projet_App.Pages.GestionCollaborateur
{
    public partial class AddEditCollaborateur
    {

        [Inject]
        private UserManager<ApplicationUser> _userManager { get; set; }
        [Inject]
        private IUserStore<ApplicationUser> _userStore { get; set; }

        [Inject]
        private ILogger<RegisterModel> _logger { get; set; }
        [Inject]
        private IMapper _mapper { get; set; }

        public RegisterModel.InputModel Input { get; set; }

        [Inject]
        private ICollaborateurService? _collaborateurService { get; set; }

        public IList<ApplicationUser> collaborateurs { get; set; }

        public int CollaborateurId { get; set; }

        [Inject]
        public UserManager<ApplicationUser> userManager { get; set; }

        [Parameter]
        public ApplicationUser? UserApp { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Input = new RegisterModel.InputModel();
            await GetCollaborateurs();
            await base.OnInitializedAsync();
        }

        protected override Task OnParametersSetAsync()
        {
            if(UserApp != null)
            {
                Input = _mapper.Map<RegisterModel.InputModel>(UserApp);
            }
            return base.OnParametersSetAsync();
        }


        async Task GetCollaborateurs()
        {
            collaborateurs = await _collaborateurService.All();
        }

        [Parameter]
        public EventCallback onItemChange { get; set; }

        public async Task Submit()
        {
            if (UserApp!=null)
            {
                UserApp = _mapper.Map<ApplicationUser>(Input);
                //await _collaborateurService.Save(UserApp);
                var res=  await _userStore.UpdateAsync(UserApp,CancellationToken.None);
                if (res.Succeeded)
                {
                Input = new RegisterModel.InputModel();

                await onItemChange.InvokeAsync();

                }
                //await userManager.UpdateAsync(UserApp);

            }
            else
            {

            var user = _mapper.Map<ApplicationUser>(Input);
            
            user.UserName = Input.FirstName + Input.LastName.Substring(0, 1).ToUpper() + Input.LastName.Substring(1);
            
            Input.Password = (Input.FirstName.Substring(0, 1).ToUpper().Trim() + Input.FirstName.Substring(1).Trim() + "123@").Trim();
            
            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");

                var userId = await _userManager.GetUserIdAsync(user);
               
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    Input = new RegisterModel.InputModel();

                    await onItemChange.InvokeAsync();
                }



            }
        }

    }

       
}
