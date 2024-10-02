using AutoMapper;
using Gestion_Projet_App.Data;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto.Projet;
using Gestion_Projet_App.Models.Entity;
using MatBlazor;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Projet_App.Services
{
    public class ProjetEquipeServie : IProjetEquipeServie
    {
        private readonly IMapper _mapper;
        private readonly IDbContextFactory<Gestion_Projet_AppContext> _contextFactory;
        private readonly IMatToaster _toaster;
        private readonly IMatDialogService _matDialogService;

        public ProjetEquipeServie(IMapper mapper, IDbContextFactory<Gestion_Projet_AppContext> contextFactory, IMatToaster Toaster, IMatDialogService matDialogService)
        {
            _mapper = mapper;
            _contextFactory = contextFactory;
            _toaster = Toaster;
            _matDialogService = matDialogService;
        }

        public async Task<List<ProjetEquipe>> All(int ProjetId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                
                List<ProjetEquipe> projetEquipes = await _context.ProjetEquipes
                  .Include( p => p.Equipe)  
                  .Include( p => p.Projet)
                  .Where(p => p.ProjetId == ProjetId ).ToListAsync();

                return projetEquipes;
            }
        }

        public async Task<bool> Delete(int ProjetEquipeId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                bool res = await _matDialogService.ConfirmAsync("Êtes-vous sûr de vouloir supprimer ce Projet Equipe ?");
                if (res)
                {
                    ProjetEquipe projetEquipe = await _context.ProjetEquipes.FirstOrDefaultAsync(p => p.Id == ProjetEquipeId);
                    if (projetEquipe != null)
                    {
                        _context.ProjetEquipes.Remove(projetEquipe);
                        _context.SaveChanges();
                        _toaster.Add("Projet Equipe supprimé avec succès", MatToastType.Success, "Message de succès");
                        return true;
                    }
                }
                return false;
            }
        }

        public async Task Save(ProjetEquipeDto request)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                string info;
                ProjetEquipe projetEquipe = _mapper.Map<ProjetEquipe>(request);

                if (!request.Id.HasValue)
                {
                    _context.ProjetEquipes.Add(projetEquipe);
                    info = "Projet Equipe enregistré avec succès";
                }
                else
                {
                    var existingEntity = await _context.Projets.FindAsync(projetEquipe.Id);
                    if (existingEntity == null)
                    {
                        _context.ProjetEquipes.Attach(projetEquipe);
                        _context.Entry(projetEquipe).State = EntityState.Modified;
                    }
                    else
                    {
                        _mapper.Map(request, existingEntity);
                    }
                    info = "Projet Equipe modifié avec succès";
                }

                await _context.SaveChangesAsync();

                _toaster.Add(info, MatToastType.Success, "Message de succès");
            }
        }
    }
}
