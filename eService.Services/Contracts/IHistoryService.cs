using System.Linq;
using eService.Data.Models;

namespace eService.Services.Contracts
{
    public interface IHistoryService
    {
        IQueryable<History> GetAll();

        IQueryable<History> GetAllAndDeleted();

        void Add(History history);

        void Update(History history);

        void Delete(History history);

        History GetDbModel();
    }
}
