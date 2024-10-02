using AutoMapper;
using Gestion_Projet_App.Data;
using Gestion_Projet_App.Models.Dto;
using Gestion_Projet_App.Models;
using MatBlazor;
using Microsoft.EntityFrameworkCore;
using Gestion_Projet_App.Models.Dto.Equipe;
using Gestion_Projet_App.Interfaces;

namespace Gestion_Projet_App.Services
{
    public class EquipeService : IEquipeService
    {
        private readonly IMapper _mapper;
        private readonly IDbContextFactory<Gestion_Projet_AppContext> _contextFactory;
        private readonly IMatToaster _toaster;
        private readonly IMatDialogService _matDialogService;

        public EquipeService(IMapper mapper, IDbContextFactory<Gestion_Projet_AppContext> contextFactory, IMatToaster Toaster, IMatDialogService matDialogService)
        {
            _mapper = mapper;
            _contextFactory = contextFactory;
            _toaster = Toaster;
            _matDialogService = matDialogService;
        }

        public async Task<List<Equipe>> All()
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                // ...
                List<Equipe> Equipes = await _context.Equipes
                    .Include(p=>p.ProjetEquipes)
                    .ToListAsync();
                return Equipes;

            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                bool res = await _matDialogService.ConfirmAsync("Êtes-vous sûr de vouloir supprimer ce Equipe ?");
                if (res)
                {
                    Equipe Equipe = await _context.Equipes.FirstOrDefaultAsync(p => p.Id == id);
                    if (Equipe != null)
                    {
                        _context.Equipes.Remove(Equipe);
                        _context.SaveChanges();
                        _toaster.Add("Equipe supprimé avec succès", MatToastType.Success, "Message de succès");
                        return true;
                    }
                }
                return false;
            }
        }

        public async Task Save(EquipeDto request)
        {
            string info;
            Equipe Equipe = _mapper.Map<Equipe>(request);

            using (var _context = _contextFactory.CreateDbContext())
            {
                if (!request.Id.HasValue)
                {
                    _context.Equipes.Add(Equipe);
                    info = "Equipe enregistré avec succès";
                }
                else
                {
                    var existingEntity = await _context.Equipes.FindAsync(Equipe.Id);
                    if (existingEntity == null)
                    {
                        _context.Equipes.Attach(Equipe);
                        _context.Entry(Equipe).State = EntityState.Modified;
                    }
                    else
                    {
                        _mapper.Map(request, existingEntity);
                    }
                    info = "Equipe modifié avec succès";
                }

                await _context.SaveChangesAsync();

                _toaster.Add(info, MatToastType.Success, "Message de succès");
            }
        }

        public async Task<List<Equipe>> Search(SearchEquipeDto request)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                List<Equipe> Equipes = await _context.Equipes
                    .Include(p=> p.Chef)
                .Where(p => ((request.Nom == " " || request.Nom == null) || p.Nom.Contains(request.Nom)))
                .ToListAsync();
                return Equipes;
            }
        }

        public async Task<Equipe> Single(int id)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                return await _context.Equipes
                    .Include(p=>p.Chef)
                    .FirstOrDefaultAsync(p => p.Id == id);
            }
        }
    }
}
