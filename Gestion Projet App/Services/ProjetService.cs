using AutoMapper;
using Gestion_Projet_App.Data;
using Gestion_Projet_App.Models.Dto.Projet;
using Gestion_Projet_App.Models;
using MatBlazor;
using Microsoft.EntityFrameworkCore;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models.outher;

namespace Gestion_Projet_App.Services
{
    public class ProjetService : IProjetService
    {
        private readonly IMapper _mapper;
        private readonly IDbContextFactory<Gestion_Projet_AppContext> _contextFactory;
        private readonly IMatToaster _toaster;
        private readonly IMatDialogService _matDialogService;

        public ProjetService(IMapper mapper, IDbContextFactory<Gestion_Projet_AppContext> contextFactory, IMatToaster Toaster, IMatDialogService matDialogService)
        {
            _mapper = mapper;
            _toaster = Toaster;
            _matDialogService = matDialogService;
            _contextFactory = contextFactory;
        }

        public async Task<List<Projet>> All()
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                List<Projet> projets = await _context.Projets.ToListAsync();
                return projets;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                bool res = await _matDialogService.ConfirmAsync("Êtes-vous sûr de vouloir supprimer ce projet ?");
                if (res)
                {
                    Projet projet = await _context.Projets.FirstOrDefaultAsync(p => p.Id == id);
                    if (projet != null)
                    {
                        _context.Projets.Remove(projet);
                        _context.SaveChanges();
                        _toaster.Add("Projet supprimé avec succès", MatToastType.Success, "Message de succès");
                        return true;
                    }
                }
                return false;
            }
        }

        public async Task Save(ProjetDto request)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                string info;
                Projet projet = _mapper.Map<Projet>(request);

                if (!request.Id.HasValue)
                {
                    _context.Projets.Add(projet);
                    info = "Projet enregistré avec succès";
                }
                else
                {
                    var existingEntity = await _context.Projets.FindAsync(projet.Id);
                    if (existingEntity == null)
                    {
                        _context.Projets.Attach(projet);
                        _context.Entry(projet).State = EntityState.Modified;
                    }
                    else
                    {
                        _mapper.Map(request, existingEntity);
                    }
                    info = "Projet modifié avec succès";
                }

                await _context.SaveChangesAsync();

                _toaster.Add(info, MatToastType.Success, "Message de succès");
            }
        }

        public async Task<List<Projet>> Search(SearchProjetDto request)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                List<Projet> projets = await _context.Projets
                     
                    .Include(p => p.Manager)
                    
                    .Include(p => p.Client)
                    
                    .Include(p=> p.ProjetEquipes)
                    
                    .ThenInclude(p=>p.Equipe)
                    
                    .ThenInclude(p=>p.EquipeCollaborateurs)

                    .Where(p => (string.IsNullOrWhiteSpace(request.Nom) || p.Nom.Contains(request.Nom))
                                && (request.DateDebut == null || p.DateDebut >= request.DateDebut)
                                && (request.DateFin == null || p.DateFin <= request.DateFin))
                    .ToListAsync();
                return projets;
            }
        }

        public async Task<Projet> Single(int id)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                return await _context.Projets.FirstOrDefaultAsync(p => p.Id == id);
            }
        }

        public async Task OnAnnuler(int projetId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                bool res = await _matDialogService.ConfirmAsync("Êtes-vous sûr de vouloir annuler ce projet ?");
                if (res)
                {
                    Projet projet = await _context.Projets.FirstOrDefaultAsync(p => p.Id == projetId);
                    if (projet != null)
                    {
                        projet.Statut = ProjetStatus.Annuler;
                        _context.Projets.Update(projet);
                        await _context.SaveChangesAsync();
                        _toaster.Add("Projet annulé avec succès", MatToastType.Success, "Message de succès");
                    }
                }
            }
        }

        public async Task OnDelancer(int projetId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                bool res = await _matDialogService.ConfirmAsync("Êtes-vous sûr de vouloir relancer ce projet ?");
                if (res)
                {
                    Projet projet = await _context.Projets.FirstOrDefaultAsync(p => p.Id == projetId);
                    if (projet != null)
                    {
                        projet.Statut = ProjetStatus.Creation;
                        _context.Projets.Update(projet);
                        await _context.SaveChangesAsync();
                        _toaster.Add("Projet relancé avec succès", MatToastType.Success, "Message de succès");
                    }
                }
            }
        }

        public async Task OnInvalider(int projetId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                bool res = await _matDialogService.ConfirmAsync("Êtes-vous sûr de vouloir invalider ce projet ?");
                if (res)
                {
                    Projet projet = await _context.Projets.FirstOrDefaultAsync(p => p.Id == projetId);
                    if (projet != null)
                    {
                        projet.Statut = ProjetStatus.EnCours;
                        _context.Projets.Update(projet);
                        await _context.SaveChangesAsync();
                        _toaster.Add("Projet invalidé avec succès", MatToastType.Success, "Message de succès");
                    }
                }
            }
        }

        public async Task OnLancer(int projetId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                bool res = await _matDialogService.ConfirmAsync("Êtes-vous sûr de vouloir lancer ce projet ?");
                if (res)
                {
                    Projet projet = await _context.Projets.FirstOrDefaultAsync(p => p.Id == projetId);
                    if (projet != null)
                    {
                        projet.Statut = ProjetStatus.EnCours;
                        _context.Projets.Update(projet);
                        await _context.SaveChangesAsync();
                        _toaster.Add("Projet lancé avec succès", MatToastType.Success, "Message de succès");
                    }
                }
            }
        }

        public async Task OnValider(int projetId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                bool res = await _matDialogService.ConfirmAsync("Êtes-vous sûr de vouloir valider ce projet ?");
                if (res)
                {
                    Projet projet = await _context.Projets.FirstOrDefaultAsync(p => p.Id == projetId);
                    if (projet != null)
                    {
                        projet.Statut = ProjetStatus.Termine;
                        _context.Projets.Update(projet);
                        await _context.SaveChangesAsync();
                        _toaster.Add("Projet validé avec succès", MatToastType.Success, "Message de succès");
                    }
                }
            }
        }
        public async Task OnReCree(int projetId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                bool res = await _matDialogService.ConfirmAsync("Êtes-vous sûr de vouloir reprendre ce projet ?");
                if (res)
                {
                    Projet projet = await _context.Projets.FirstOrDefaultAsync(p => p.Id == projetId);
                    if (projet != null && projet.Statut != ProjetStatus.Creation)
                    {
                        projet.Statut = ProjetStatus.Creation;
                        _context.Projets.Update(projet);
                        await _context.SaveChangesAsync();
                        _toaster.Add("Projet repris avec succès", MatToastType.Success, "Message de succès");
                    }
                    else
                    {
                        _toaster.Add("Le projet est déjà en statut 'Création'", MatToastType.Warning, "Avertissement");
                    }
                }
            }
        }


    }
}
