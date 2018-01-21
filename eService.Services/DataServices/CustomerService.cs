using System.Linq;
using eService.Data.Contracts;
using eService.Data.Models;
using eService.Services.Contracts;

namespace eService.Services.DataServices
{
    public class CustomerService : ICustomerService
    {
        private readonly IEfRepository<Customer> clientRepo;
        private readonly ISaveContext context;

        public CustomerService(IEfRepository<Customer> clientRepo, ISaveContext context)
        {
            this.clientRepo = clientRepo;
            this.context = context;
        }

        public IQueryable<Customer> GetAll()
        {
            return this.clientRepo.All;
        }

        public IQueryable<Customer> GetAllAndDeleted()
        {
            return this.clientRepo.AllAndDeleted;
        }

        public void Add(Customer client)
        {
            this.clientRepo.Add(client);
            this.context.Commit();
        }

        public void Update(Customer client)
        {
            this.clientRepo.Update(client);
            this.context.Commit();
        }

        public void Delete(Customer client)
        {
            this.clientRepo.Delete(client);
            this.context.Commit();
        }

        public Customer GetDbModel()
        {
            return new Customer();
        }
    }
}

