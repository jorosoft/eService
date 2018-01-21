using System.Linq;
using eService.Data.Contracts;
using eService.Data.Models;
using eService.Services.Contracts;

namespace eService.Services.DataServices
{
    public class SupplierService : ISupplierService
    {
        private readonly IEfRepository<Supplier> supplierRepo;
        private readonly ISaveContext context;

        public SupplierService(IEfRepository<Supplier> supplierRepo, ISaveContext context)
        {
            this.supplierRepo = supplierRepo;
            this.context = context;
        }

        public IQueryable<Supplier> GetAll()
        {
            return this.supplierRepo.All;
        }

        public IQueryable<Supplier> GetAllAndDeleted()
        {
            return this.supplierRepo.AllAndDeleted;
        }

        public void Add(Supplier supplier)
        {
            this.supplierRepo.Add(supplier);
            this.context.Commit();
        }

        public void Update(Supplier supplier)
        {
            this.supplierRepo.Update(supplier);
            this.context.Commit();
        }

        public void Delete(Supplier supplier)
        {
            this.supplierRepo.Delete(supplier);
            this.context.Commit();
        }

        public Supplier GetDbModel()
        {
            return new Supplier();
        }
    }
}

