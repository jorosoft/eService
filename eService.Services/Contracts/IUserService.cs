using System.Linq;
using eService.Data.Models;

namespace eService.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<User> GetAll();

        IQueryable<User> GetAllAndDeleted();

        void Add(User user);

        void Update(User user);

        void Delete(User user);

        User GetDbModel();
    }
}
