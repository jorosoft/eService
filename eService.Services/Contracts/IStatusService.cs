using System.Linq;
using eService.Data.Models;

namespace eService.Services.Contracts
{
    public interface IStatusService
    {
        IQueryable<Status> GetAll();

        IQueryable<Status> GetAllAndDeleted();

        void Add(Status status);

        void Update(Status status);

        void Delete(Status status);

        Status GetDbModel();
    }
}
