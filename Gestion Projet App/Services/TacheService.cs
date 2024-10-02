using AutoMapper;
using MatBlazor;
using Microsoft.EntityFrameworkCore;
using Gestion_Projet_App.Data;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto.Taches;
using Gestion_Projet_App.Models.outher;
using System.Collections.ObjectModel;
using Microsoft.CodeAnalysis;

namespace Gestion_Tache_App.Services
{
    public class TacheService : ITacheService
    {
        private readonly IMapper _mapper;
        private readonly IDbContextFactory<Gestion_Projet_AppContext> _contextFactory;
        private readonly IMatToaster _toaster;
        private readonly IMatDialogService _matDialogService;

        public TacheService(IMapper mapper, IDbContextFactory<Gestion_Projet_AppContext> contextFactory, IMatToaster Toaster, IMatDialogService matDialogService)
        {
            _mapper = mapper;
            _contextFactory = contextFactory;
            _toaster = Toaster;
            _matDialogService = matDialogService;
        }



        public async Task<bool> Delete(int id)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                bool res = await _matDialogService.ConfirmAsync("Êtes-vous sûr de vouloir supprimer ce Tache ?");
                if (res)
                {
                    Tache Tache = await _context.Taches.FirstOrDefaultAsync(p => p.Id == id);
                    if (Tache != null)
                    {
                        _context.Taches.Remove(Tache);
                        _context.SaveChanges();
                        _toaster.Add("Tache supprimé avec succès", MatToastType.Success, "Message de succès");
                        return true;
                    }
                }
                return false;
            }
        }



        public async Task<TacheDto> Save(TacheDto request)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                string info;
                Tache Tache = _mapper.Map<Tache>(request);

                if (!request.Id.HasValue)
                {
                    _context.Taches.Add(Tache);
                    info = "Tache enregistré avec succès";

                }
                else
                {
                    var existingEntity = await _context.Taches.FindAsync(Tache.Id);
                    if (existingEntity == null)
                    {
                        _context.Taches.Attach(Tache);
                        _context.Entry(Tache).State = EntityState.Modified;
                        return _mapper.Map<TacheDto>(Tache);
                    }
                    else
                    {
                        _mapper.Map(request, existingEntity);
                        Tache = existingEntity;
                    }
                    info = "Tache modifié avec succès";
                }

                await _context.SaveChangesAsync();

                _toaster.Add(info, MatToastType.Success, "Message de succès");
                return _mapper.Map<TacheDto>(Tache);
            }
        }

        public async Task<List<Tache>> GetCreatedTache(int ProjetId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                List<Tache> taches = await _context.Taches
                       .Include(p => p.TacheCollaborateurs)
                     .ThenInclude(p => p.Collaborateur)
                    .Where(p => p.ProjetId == ProjetId && p.Statut == TacheStatus.Creation).ToListAsync();
                return taches;
            }
        }

        public async Task<List<Tache>> GetDeployeeTache(int ProjetId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                List<Tache> taches = await _context.Taches
                       .Include(p => p.TacheCollaborateurs)
                     .ThenInclude(p => p.Collaborateur)
                    .Where(p => p.ProjetId == ProjetId && p.Statut == TacheStatus.Deployer).ToListAsync();
                return taches;
            }
        }

        public async Task<List<Tache>> GetEncourTache(int ProjetId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                List<Tache> taches = await _context.Taches
                       .Include(p => p.TacheCollaborateurs)
                     .ThenInclude(p => p.Collaborateur)
                    .Where(p => p.ProjetId == ProjetId && p.Statut == TacheStatus.EnCours).ToListAsync();
                return taches;
            }
        }

        public async Task<List<Tache>> GetTermineTache(int ProjetId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {

                List<Tache> taches = await _context.Taches
                       .Include(p => p.TacheCollaborateurs)
                     .ThenInclude(p => p.Collaborateur)
                    .Where(p => p.ProjetId == ProjetId && p.Statut == TacheStatus.Termine).ToListAsync();
                return taches;
            }
        }

        public async Task<List<Tache>> All(int ProjetId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                List<Tache> taches = await _context.Taches 
                     .Include( p=>p.TacheCollaborateurs)
                     .ThenInclude( p=> p.Collaborateur)
                    .Where(p => p.ProjetId == ProjetId).ToListAsync();
                return taches;
            }
        }
    }
}
