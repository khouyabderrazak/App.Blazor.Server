using AutoMapper;
using Gestion_Projet_App.Data;
using Gestion_Projet_App.Interfaces;
using Gestion_Projet_App.Models.Dto.Client;
using Gestion_Projet_App.Models.Entity;
using MatBlazor;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Projet_App.Services
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly IDbContextFactory<Gestion_Projet_AppContext> _contextFactory;
        private readonly IMatToaster _toaster;
        private readonly IMatDialogService _matDialogService;

        public ClientService(IMapper mapper, IDbContextFactory<Gestion_Projet_AppContext> contextFactory, IMatToaster Toaster, IMatDialogService matDialogService)
        {
            _mapper = mapper;
            _contextFactory = contextFactory;
            _toaster = Toaster;
            _matDialogService = matDialogService;
        }

        public async Task<List<Client>> All()
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                // ...
                List<Client> Clients = await _context.Clients.ToListAsync();
                return Clients;

            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                bool res = await _matDialogService.ConfirmAsync("Êtes-vous sûr de vouloir supprimer ce Client ?");
                if (res)
                {
                    Client Client = await _context.Clients.FirstOrDefaultAsync(p => p.Id == id);
                    if (Client != null)
                    {
                        _context.Clients.Remove(Client);
                        _context.SaveChanges();
                        _toaster.Add("Client supprimé avec succès", MatToastType.Success, "Message de succès");
                        return true;
                    }
                }
                return false;
            }
        }

        public async Task Save(ClientDto request)
        {
            string info;
            Client Client = _mapper.Map<Client>(request);

            using (var _context = _contextFactory.CreateDbContext())
            {
                if (!request.Id.HasValue)
                {
                    _context.Clients.Add(Client);
                    info = "Client enregistré avec succès";
                }
                else
                {
                    var existingEntity = await _context.Clients.FindAsync(Client.Id);
                    if (existingEntity == null)
                    {
                        _context.Clients.Attach(Client);
                        _context.Entry(Client).State = EntityState.Modified;
                    }
                    else
                    {
                        _mapper.Map(request, existingEntity);
                    }
                    info = "Client modifié avec succès";
                }

                await _context.SaveChangesAsync();

                _toaster.Add(info, MatToastType.Success, "Message de succès");
            }
        }

        public async Task<List<Client>> Search(SearchClientDto request)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                List<Client> Clients = await _context.Clients
                .Where(p => ((request.Name == " " || request.Name == null) || p.Name.Contains(request.Name))).ToListAsync();
                return Clients;
            }
        }
    }
}
