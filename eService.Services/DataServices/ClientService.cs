using System.Linq;
using eService.Data.Contracts;
using eService.Data.Models;
using eService.Services.Contracts;

namespace eService.Services.DataServices
{
    public class ClientService : IClientService
    {
        private readonly IEfRepository<Client> clientRepo;
        private readonly ISaveContext context;

        public ClientService(IEfRepository<Client> clientRepo, ISaveContext context)
        {
            this.clientRepo = clientRepo;
            this.context = context;
        }

        public IQueryable<Client> GetAll()
        {
            return this.clientRepo.All;
        }

        public IQueryable<Client> GetAllAndDeleted()
        {
            return this.clientRepo.AllAndDeleted;
        }

        public void Add(Client client)
        {
            this.clientRepo.Add(client);
            this.context.Commit();
        }

        public void Update(Client client)
        {
            this.clientRepo.Update(client);
            this.context.Commit();
        }

        public void Delete(Client client)
        {
            this.clientRepo.Delete(client);
            this.context.Commit();
        }

        public Client GetDbModel()
        {
            return new Client();
        }
    }
}

