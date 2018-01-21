using System.Linq;
using eService.Data.Models;

namespace eService.Services.Contracts
{
    public interface IStreetService
    {
        IQueryable<Street> GetAll();

        IQueryable<Street> GetAllAndDeleted();

        void Add(Street street);

        void Update(Street street);

        void Delete(Street street);

        Street GetDbModel();
    }
}
