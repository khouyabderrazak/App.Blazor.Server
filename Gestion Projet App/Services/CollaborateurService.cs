using AutoMapper;
using Gestion_Projet_App.Data;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models;
using Gestion_Projet_App.Models.Dto;
using Gestion_Projet_App.Models.Entity;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Projet_App.Services
{
    public class CollaborateurService : ICollaborateurService
    {
        private readonly IMapper _mapper;
        private readonly IDbContextFactory<Gestion_Projet_AppContext> _contextFactory;
        private readonly IMatToaster _toaster;
        private readonly IMatDialogService _matDialogService;

        public CollaborateurService(IMapper mapper, IDbContextFactory<Gestion_Projet_AppContext> contextFactory, IMatToaster Toaster, IMatDialogService matDialogService)
        {
            _mapper = mapper;
            _contextFactory = contextFactory;
            _toaster = Toaster;
            _matDialogService = matDialogService;
        }

        public async Task<List<ApplicationUser>> All()
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                // ...
            List<ApplicationUser> collaborateurs = await _context.Users
                    .Include( p=> p.EquipeCollaborateurs)
                    .ToListAsync();
            return collaborateurs;

            }
        }

        public async Task<List<ApplicationUser>> AllFromProjetEquipes(int tacheId)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                 
                 List<ApplicationUser> collaborateurs =await  _context.Taches
                    
                .Include(t => t.Projet)
                .ThenInclude(t => t.ProjetEquipes)
                .ThenInclude(t => t.Equipe)
                .ThenInclude(t => t.EquipeCollaborateurs)

                .Where(t => t.Id == tacheId)
                
                .Select(p => p.Projet)
                .SelectMany(p => p.ProjetEquipes)
                .Select(p => p.Equipe)
                .SelectMany(p => p.EquipeCollaborateurs).Select(p=>p.Collaborateur).ToListAsync();

               

                return collaborateurs;
            }
        }

        public async Task<bool> Delete(string id)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                bool res = await _matDialogService.ConfirmAsync("Êtes-vous sûr de vouloir supprimer ce collaborateur ?");
                if (res)
                {
                    ApplicationUser collaborateur = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
                    if (collaborateur != null)
                    {
                        _context.Users.Remove(collaborateur);
                        _context.SaveChanges();
                        _toaster.Add("Collaborateur supprimé avec succès", MatToastType.Success, "Message de succès");
                        return true;
                    }
                }
                return false;
            }
        }

        public async Task Save(ApplicationUser request)
        {
            string info;

            using (var _context = _contextFactory.CreateDbContext())
            {
               
                    var existingEntity = await _context.Users.FindAsync(request.Id);
                    if (existingEntity == null)
                    {
                        _context.Users.Attach(request);
                        _context.Entry(request).State = EntityState.Modified;
                    }
                    else
                    {
                        _mapper.Map(request, existingEntity);
                    }
                    info = "Collaborateur modifié avec succès";

                await _context.SaveChangesAsync();

                _toaster.Add(info, MatToastType.Success, "Message de succès");
            }
        }

        public async Task<List<ApplicationUser>> Search(SearchCollaborateurDto request)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                List<ApplicationUser> collaborateurs = await _context.Users
                .Where(p => 
                    ((request.LastName == " " || request.LastName == null) || p.LastName.Contains(request.LastName))
                    && (request.Active == null  || p.Active == request.Active)
                    && ((request.FirstName == " " || request.FirstName == null) || p.FirstName.Contains(request.FirstName))
                )
                .ToListAsync();
                return collaborateurs;
            }
        }

        public async Task<ApplicationUser> Single(string id)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                return await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
            }
        }


    }
}
