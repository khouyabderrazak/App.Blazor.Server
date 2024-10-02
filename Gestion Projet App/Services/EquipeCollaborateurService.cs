using AutoMapper;
using Gestion_Projet_App.Data;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto.EquipeCollaborateur;
using MatBlazor;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Projet_App.Services
{
    public class EquipeCollaborateurService : IEquipeCollaborateurService
    {

        private readonly IMapper _mapper;
        private readonly IDbContextFactory<Gestion_Projet_AppContext> _contextFactory;
        private readonly IMatToaster _toaster;
        private readonly IMatDialogService _matDialogService;

        public EquipeCollaborateurService(IMapper mapper, IDbContextFactory<Gestion_Projet_AppContext> contextFactory, IMatToaster Toaster, IMatDialogService matDialogService)
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
                bool res = await _matDialogService.ConfirmAsync("Êtes-vous sûr de vouloir supprimer ce Collaborateur ?");
                if (res)
                {
                    EquipeCollaborateur EquipeCollaborateur = await _context.EquipeCollaborateurs.FirstOrDefaultAsync(p => p.Id == id);
                    if (EquipeCollaborateur != null)
                    {
                        _context.EquipeCollaborateurs.Remove(EquipeCollaborateur);
                        _context.SaveChanges();
                        _toaster.Add("Collaborateur supprimé avec succès", MatToastType.Success, "Message de succès");
                        return true;
                    }
                }
                return false;
            }
        }

        public async Task Save(EquipeCollaborateurDto request)
        {
            string info;
            EquipeCollaborateur EquipeCollaborateur = _mapper.Map<EquipeCollaborateur>(request);

            using (var _context = _contextFactory.CreateDbContext())
            {
                EquipeCollaborateur equipeCollaborateur = await _context.EquipeCollaborateurs.FirstOrDefaultAsync(p => p.CollaborateurId == request.CollaborateurId && p.EquipeId == request.EquipeId );
                if(equipeCollaborateur == null)
                {
                 _context.EquipeCollaborateurs.Add(EquipeCollaborateur);
                 info = "Collaborateur enregistré avec succès";
                
                await _context.SaveChangesAsync();
                _toaster.Add(info, MatToastType.Success, "Message de succès");

                }
                else
                {
                    info = "Collaborateur déja ajouter au cet'equipe";
                _toaster.Add(info, MatToastType.Warning, "Message de Error");
                }

            }
        }

        public async Task<List<EquipeCollaborateur>> Search(int EquipeId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                List<EquipeCollaborateur> EquipeCollaborateurs = await _context.EquipeCollaborateurs
                    .Include(p => p.Equipe)
                    .Include(p => p.Collaborateur)
                .Where(p => p.EquipeId == EquipeId )
                .ToListAsync();
                return EquipeCollaborateurs;
            }
        }

    }
}
