using System.Linq;
using eService.Data.Contracts;
using eService.Data.Models;
using eService.Services.Contracts;

namespace eService.Services.DataServices
{
    public class TownService : ITownService
    {
        private readonly IEfRepository<Town> cityRepo;
        private readonly ISaveContext context;

        public TownService(IEfRepository<Town> cityRepo, ISaveContext context)
        {
            this.cityRepo = cityRepo;
            this.context = context;
        }

        public IQueryable<Town> GetAll()
        {
            return this.cityRepo.All;
        }

        public IQueryable<Town> GetAllAndDeleted()
        {
            return this.cityRepo.AllAndDeleted;
        }

        public void Add(Town city)
        {
            this.cityRepo.Add(city);
            this.context.Commit();
        }

        public void Update(Town city)
        {
            this.cityRepo.Update(city);
            this.context.Commit();
        }

        public void Delete(Town city)
        {
            this.cityRepo.Delete(city);
            this.context.Commit();
        }

        public Town GetDbModel()
        {
            return new Town();
        }
    }
}
