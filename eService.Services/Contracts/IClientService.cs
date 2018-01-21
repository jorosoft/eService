using System.Linq;
using eService.Data.Models;

namespace eService.Services.Contracts
{
    public interface IClientService
    {
        IQueryable<Client> GetAll();

        IQueryable<Client> GetAllAndDeleted();

        void Add(Client client);

        void Update(Client client);

        void Delete(Client client);

        Client GetDbModel();
    }
}
