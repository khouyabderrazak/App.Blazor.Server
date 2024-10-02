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
        private ILogger<RegisterModel> _logger { get; set; }

        public RegisterModel.InputModel Input { get; set; }

        [Inject]
        private ICollaborateurService? _collaborateurService { get; set; }

        public IList<ApplicationUser> collaborateurs { get; set; }

        public int CollaborateurId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Input = new RegisterModel.InputModel();

            await GetCollaborateurs();

            await base.OnInitializedAsync();
        }

        async Task GetCollaborateurs()
        {
            collaborateurs = await _collaborateurService.All();
        }

        [Parameter]
        public EventCallback onItemChange { get; set; }

        public async Task Submit()
        {
            var user = new ApplicationUser { 
                 UserName = Input.FirstName + Input.LastName
                , Email = Input.Email
                ,FirstName = Input.FirstName
                ,LastName = Input.LastName
                ,Active = Input.Active
                ,Address = Input.Address
                ,PhoneNumber = Input.PhoneNumber
            };

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
