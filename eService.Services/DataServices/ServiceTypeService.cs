using System.Linq;
using eService.Data.Contracts;
using eService.Data.Models;
using eService.Services.Contracts;

namespace eService.Services.DataServices
{
    public class ServiceTypeService :IServiceTypeService
    {
        private readonly IEfRepository<ServiceType> serviceTypeRepo;
        private readonly ISaveContext context;

        public ServiceTypeService(IEfRepository<ServiceType> serviceTypeRepo, ISaveContext context)
        {
            this.serviceTypeRepo = serviceTypeRepo;
            this.context = context;
        }

        public IQueryable<ServiceType> GetAll()
        {
            return this.serviceTypeRepo.All;
        }

        public IQueryable<ServiceType> GetAllAndDeleted()
        {
            return this.serviceTypeRepo.AllAndDeleted;
        }

        public void Add(ServiceType serviceType)
        {
            this.serviceTypeRepo.Add(serviceType);
            this.context.Commit();
        }

        public void Update(ServiceType serviceType)
        {
            this.serviceTypeRepo.Update(serviceType);
            this.context.Commit();
        }

        public void Delete(ServiceType serviceType)
        {
            this.serviceTypeRepo.Delete(serviceType);
            this.context.Commit();
        }

        public ServiceType GetDbModel()
        {
            return new ServiceType();
        }
    }
}

