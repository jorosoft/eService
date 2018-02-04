using System.Linq;
using eService.Data.Contracts;
using eService.Data.Models;
using eService.Services.Contracts;

namespace eService.Services.DataServices
{
    public class StreetService : IStreetService
    {
        private readonly IEfRepository<Street> streetRepo;
        private readonly ISaveContext context;

        public StreetService(IEfRepository<Street> streetRepo, ISaveContext context)
        {
            this.streetRepo = streetRepo;
            this.context = context;
        }

        public IQueryable<Street> GetAll()
        {
            return this.streetRepo.All;
        }

        public IQueryable<Street> GetAllAndDeleted()
        {
            return this.streetRepo.AllAndDeleted;
        }

        public void Add(Street street)
        {
            this.streetRepo.Add(street);
            this.context.Commit();
        }

        public void Update(Street street)
        {
            this.streetRepo.Update(street);
            this.context.Commit();
        }

        public void Delete(Street street)
        {
            this.streetRepo.Delete(street);
            this.context.Commit();
        }

        public Street GetDbModel(string name)
        {
            var street = this.streetRepo.All
                .FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

            if (street == null)
            {
                street = new Street
                {
                    Name = name
                };

                this.streetRepo.Add(street);
            }

            return street;
        }
    }
}

