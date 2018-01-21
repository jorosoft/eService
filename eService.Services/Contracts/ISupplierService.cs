using System.Linq;
using eService.Data.Models;

namespace eService.Services.Contracts
{
    public interface ISupplierService
    {
        IQueryable<Supplier> GetAll();

        IQueryable<Supplier> GetAllAndDeleted();

        void Add(Supplier supplier);

        void Update(Supplier supplier);

        void Delete(Supplier supplier);

        Supplier GetDbModel();
    }
}
