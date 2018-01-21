using System.Linq;
using eService.Data.Models;

namespace eService.Services.Contracts
{
    public interface ICityService
    {
        IQueryable<City> GetAll();

        IQueryable<City> GetAllAndDeleted();

        void Add(City city);

        void Update(City city);

        void Delete(City city);

        City GetDbModel();
    }
}
