using System.Linq;
using eService.Data.Contracts;
using eService.Data.Models;
using eService.Services.Contracts;

namespace eService.Services.DataServices
{
    public class CityService : ICityService
    {
        private readonly IEfRepository<City> cityRepo;
        private readonly ISaveContext context;

        public CityService(IEfRepository<City> cityRepo, ISaveContext context)
        {
            this.cityRepo = cityRepo;
            this.context = context;
        }

        public IQueryable<City> GetAll()
        {
            return this.cityRepo.All;
        }

        public IQueryable<City> GetAllAndDeleted()
        {
            return this.cityRepo.AllAndDeleted;
        }

        public void Add(City city)
        {
            this.cityRepo.Add(city);
            this.context.Commit();
        }

        public void Update(City city)
        {
            this.cityRepo.Update(city);
            this.context.Commit();
        }

        public void Delete(City city)
        {
            this.cityRepo.Delete(city);
            this.context.Commit();
        }

        public City GetDbModel()
        {
            return new City();
        }
    }
}
