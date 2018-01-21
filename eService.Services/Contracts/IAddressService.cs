using System.Linq;
using eService.Data.Models;

namespace eService.Services.Contracts
{
    public interface IAddressService
    {
        IQueryable<Address> GetAll();

        IQueryable<Address> GetAllAndDeleted();

        void Add(Address address);

        void Update(Address address);

        void Delete(Address address);

        Address GetDbModel();
    }
}
