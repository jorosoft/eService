using System.Linq;
using eService.Data.Models;

namespace eService.Services.Contracts
{
    public interface ICustomerService
    {
        IQueryable<Customer> GetAll();

        IQueryable<Customer> GetAllAndDeleted();

        void Add(Customer customer);

        void Update(Customer customer);

        void Delete(Customer customer);

        Customer GetDbModel();
    }
}
