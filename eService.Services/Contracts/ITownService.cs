using System.Linq;
using eService.Data.Models;

namespace eService.Services.Contracts
{
    public interface ITownService
    {
        IQueryable<Town> GetAll();

        IQueryable<Town> GetAllAndDeleted();

        void Add(Town city);

        void Update(Town city);

        void Delete(Town city);

        Town GetDbModel();
    }
}
