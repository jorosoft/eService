using System.Linq;
using eService.Data.Models;

namespace eService.Services.Contracts
{
    public interface IServiceTypeService
    {
        IQueryable<ServiceType> GetAll();

        IQueryable<ServiceType> GetAllAndDeleted();

        void Add(ServiceType serviceType);

        void Update(ServiceType serviceType);

        void Delete(ServiceType serviceType);

        ServiceType GetDbModel();
    }
}
