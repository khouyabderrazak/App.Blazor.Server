using AutoMapper;
using Gestion_Projet_App.Data;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models.Dto.Projet;
using Gestion_Projet_App.Models;
using MatBlazor;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Projet_App.Services
{
    public class TacheCollaborateursService : ITacheCollaborateursService
    {
        private readonly IMapper _mapper;
        private readonly IDbContextFactory<Gestion_Projet_AppContext> _contextFactory;
        private readonly IMatToaster _toaster;
        private readonly IMatDialogService _matDialogService;

        public TacheCollaborateursService(IMapper mapper, IDbContextFactory<Gestion_Projet_AppContext> contextFactory, IMatToaster Toaster, IMatDialogService matDialogService)
        {
            _mapper = mapper;
            _contextFactory = contextFactory;
            _toaster = Toaster;
            _matDialogService = matDialogService;
        }

        public async Task<List<TacheCollaborateur>> All(int TacheId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                List<TacheCollaborateur> tacheCollaborateurs = await _context.TacheCollaborateurs
                  .Where(p => p.TacheId == TacheId).ToListAsync();
                return tacheCollaborateurs;
            }
        }

        public async Task<bool> Delete(string collaborateurId,int tacheId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {

                TacheCollaborateur tacheCollaborateur = await _context.TacheCollaborateurs.FirstOrDefaultAsync(p => p.CollaborateurId == collaborateurId && p.TacheId == tacheId);
                if (tacheCollaborateur != null)
                {
                    _context.TacheCollaborateurs.Remove(tacheCollaborateur);
                    _context.SaveChanges();
                    _toaster.Add("Projet supprimé avec succès", MatToastType.Success, "Message de succès");
                    return true;
                }
                return false;
            }
        }

        public async Task Save(TacheCollaborateurDto request)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                string info;
                TacheCollaborateur tacheCollaborateur = _mapper.Map<TacheCollaborateur>(request);

                if (!request.Id.HasValue)
                {
                    _context.TacheCollaborateurs.Add(tacheCollaborateur);
                    info = "Projet enregistré avec succès";
                }
                else
                {
                    var existingEntity = await _context.Projets.FindAsync(tacheCollaborateur.Id);
                    if (existingEntity == null)
                    {
                        _context.TacheCollaborateurs.Attach(tacheCollaborateur);
                        _context.Entry(tacheCollaborateur).State = EntityState.Modified;
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
    }
}
