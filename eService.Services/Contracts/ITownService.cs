using System.Linq;
using eService.Data.Models;

namespace eService.Services.Contracts
{
    public interface ITownService
    {
        IQueryable<Town> GetAll();

        IQueryable<Town> GetAllAndDeleted();

        void Add(Town town);

        void Update(Town town);

        void Delete(Town town);

        Town GetDbModel();
    }
}
