using AutoMapper;
using Gestion_Projet_App.Areas.Identity.Pages.Account;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto;
using Gestion_Projet_App.Models.Dto.Client;
using Gestion_Projet_App.Models.Dto.Equipe;
using Gestion_Projet_App.Models.Dto.EquipeCollaborateur;
using Gestion_Projet_App.Models.Dto.Projet;
using Gestion_Projet_App.Models.Dto.Taches;
using Gestion_Projet_App.Models.Entity;

namespace Gestion_Projet_App
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Projet, ProjetDto>().ReverseMap();
            CreateMap<TacheDto, Tache>().ReverseMap();
            CreateMap<TacheCollaborateurDto, TacheCollaborateur>().ReverseMap();
            CreateMap<ClientDto, Client>().ReverseMap();
            CreateMap<EquipeDto, Equipe>().ReverseMap();
            CreateMap<EquipeCollaborateurDto, EquipeCollaborateur>().ReverseMap();
            CreateMap<ProjetEquipeDto, ProjetEquipe>().ReverseMap();
            CreateMap<ApplicationUser, RegisterModel.InputModel>().ReverseMap();
        }
    }
}
