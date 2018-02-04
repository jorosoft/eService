using System.Linq;
using eService.Data.Contracts;
using eService.Data.Models;
using eService.Services.Contracts;

namespace eService.Services.DataServices
{
    public class TownService : ITownService
    {
        private readonly IEfRepository<Town> townRepo;
        private readonly ISaveContext context;

        public TownService(IEfRepository<Town> townRepo, ISaveContext context)
        {
            this.townRepo = townRepo;
            this.context = context;
        }

        public IQueryable<Town> GetAll()
        {
            return this.townRepo.All;
        }

        public IQueryable<Town> GetAllAndDeleted()
        {
            return this.townRepo.AllAndDeleted;
        }

        public void Add(Town town)
        {
            this.townRepo.Add(town);
            this.context.Commit();
        }

        public void Update(Town town)
        {
            this.townRepo.Update(town);
            this.context.Commit();
        }

        public void Delete(Town town)
        {
            this.townRepo.Delete(town);
            this.context.Commit();
        }

        public Town GetDbModel(string name)
        {
            var town = this.townRepo.All
                .FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

            if (town == null)
            {
                town = new Town
                {
                    Name = name
                };

                this.townRepo.Add(town);
            }

            return town;
        }
    }
}
