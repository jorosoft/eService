using System.Linq;
using eService.Data.Contracts;
using eService.Data.Models;

namespace eService.Services.DataServices
{
    public class AddressService
    {
        private readonly IEfRepository<Address> addressRepo;
        private readonly ISaveContext context;

        public AddressService(IEfRepository<Address> addressRepo, ISaveContext context)
        {
            this.addressRepo = addressRepo;
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

        public Address GetDbModel()
        {
            return new Address();
        }
    }
}

