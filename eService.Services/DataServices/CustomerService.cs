using System.Linq;
using eService.Data.Contracts;
using eService.Data.Models;
using eService.Services.Contracts;

namespace eService.Services.DataServices
{
    public class CustomerService : ICustomerService
    {
        private readonly IEfRepository<Customer> customerRepo;
        private readonly ISaveContext context;

        public CustomerService(IEfRepository<Customer> customerRepo, ISaveContext context)
        {
            this.customerRepo = customerRepo;
            this.context = context;
        }

        public IQueryable<Customer> GetAll()
        {
            return this.customerRepo.All;
        }

        public IQueryable<Customer> GetAllAndDeleted()
        {
            return this.customerRepo.AllAndDeleted;
        }

        public void Add(Customer customer)
        {
            this.customerRepo.Add(customer);
            this.context.Commit();
        }

        public void Update(Customer customer)
        {
            this.customerRepo.Update(customer);
            this.context.Commit();
        }

        public void Delete(Customer customer)
        {
            this.customerRepo.Delete(customer);
            this.context.Commit();
        }

        public Customer GetDbModel()
        {
            return new Customer();
        }
    }
}

