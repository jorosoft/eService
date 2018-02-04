using System.Linq;
using eService.Data.Contracts;
using eService.Data.Models;
using eService.Services.Contracts;

namespace eService.Services.DataServices
{
    public class AddressService : IAddressService
    {
        private readonly IEfRepository<Address> addressRepo;
        private readonly ITownService townService;
        private readonly IStreetService streetService;
        private readonly ISaveContext context;

        public AddressService(
            IEfRepository<Address> addressRepo,
            ITownService townService,
            IStreetService streetService,
            ISaveContext context)
        {
            this.addressRepo = addressRepo;
            this.townService = townService;
            this.streetService = streetService;
            this.context = context;
        }

        public IQueryable<Address> GetAll()
        {
            return this.addressRepo.All;
        }

        public IQueryable<Address> GetAllAndDeleted()
        {
            return this.addressRepo.AllAndDeleted;
        }

        public void Add(Address address)
        {
            this.addressRepo.Add(address);
            this.context.Commit();
        }

        public void Update(Address address)
        {
            this.addressRepo.Update(address);
            this.context.Commit();
        }

        public void Delete(Address address)
        {
            this.addressRepo.Delete(address);
            this.context.Commit();
        }

        public Address GetDbModel(string town, string street)
        {
            var townEntity = this.townService.GetDbModel(town);
            var streetEntity = this.streetService.GetDbModel(street);

            return new Address { Town = townEntity, Street = streetEntity};
        }
    }
}

