using AutoMapper;
using Gestion_Projet_App.Data;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Entity;
using Gestion_Projet_App.Models.outher;
using MatBlazor;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Projet_App.Services
{
    public class AcceuilService :IAcceuilService
    {
        private readonly IMapper _mapper;
        private readonly IDbContextFactory<Gestion_Projet_AppContext> _contextFactory;
        private readonly IMatToaster _toaster;
        private readonly IMatDialogService _matDialogService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AcceuilService(IMapper mapper, IDbContextFactory<Gestion_Projet_AppContext> contextFactory, IMatToaster Toaster, IMatDialogService matDialogService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _contextFactory = contextFactory;
            _toaster = Toaster;
            _matDialogService = matDialogService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        
        public async Task<Acceuil> AllData() {
            using (var _context = _contextFactory.CreateDbContext())
            {
                IList<ApplicationUser> collaborateurs =await  _context.Users.ToListAsync();
                var totalCollaborateur = collaborateurs.Count;
                var totalCollaborateurActive = collaborateurs.Where(p => p.Active == true).Count();
                var totalCollaborateurInActive = totalCollaborateur - totalCollaborateurActive;

                IList<Projet> projets = await _context.Projets.ToListAsync();

                var totalProjetEncour = projets.Where(p => p.Statut == ProjetStatus.EnCours).Count();
                var totalProjetTerminer = projets.Where(p => p.Statut == ProjetStatus.Termine).Count();
                var totalProjetAnnuler = projets.Where(p => p.Statut == ProjetStatus.Annuler).Count();
                var totalProjet = projets.Count;

                var totalProjetEnRetard = projets.Where(p => p.DateFin < DateTime.UtcNow && p.Statut != ProjetStatus.Termine && p.Statut != ProjetStatus.Annuler ).Count();
                IList<ApplicationUser> users  = await _context.Users.ToListAsync();

                var usersInRole = await _userManager.GetUsersInRoleAsync("ProjetManager");
                var totalChefprojet = usersInRole?.Count;

                var TotalchefProjetActifs = usersInRole.Where(p => projets.Any(pr => pr.ManagerID == p.Id && pr.Statut == ProjetStatus.EnCours)).Count();

                IList<Equipe> equipes = await _context.Equipes.ToListAsync();
                var totalEquipe = equipes.Count;

                IList<Client> clients = await _context.Clients.ToListAsync();
                var totalClient = clients.Count;

                Acceuil acceuil = new Acceuil()
                {
                    TotalClient= totalClient,
                    TotalCollaborateur=totalCollaborateur,
                    TotalCollaborateurActive=totalCollaborateurActive,
                    TotalCollaborateurnInactive=totalCollaborateurInActive,
                    TotalEquipe=totalEquipe,
                    TotalProjet=totalProjet,
                    TotalProjetAnuller=totalProjetAnnuler,
                    TotalProjetEncour=totalProjetEncour,
                    TotalProjetTerminer=totalProjetTerminer,
                    TotalProjetEnRetard = totalProjetEnRetard,
                    TotalChefProjet = totalChefprojet,
                    TotalChefProjetEncours = TotalchefProjetActifs
                    
                };

                return acceuil;
            } 
        }
    }

}
