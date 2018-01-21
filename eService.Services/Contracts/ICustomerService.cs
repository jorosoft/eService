using System.Linq;
using eService.Data.Models;

namespace eService.Services.Contracts
{
    public interface ICustomerService
    {
        IQueryable<Customer> GetAll();

        IQueryable<Customer> GetAllAndDeleted();

        void Add(Customer client);

        void Update(Customer client);

        void Delete(Customer client);

        Customer GetDbModel();
    }
}
