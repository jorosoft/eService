using System.Linq;
using eService.Data.Contracts;
using eService.Data.Models;
using eService.Services.Contracts;

namespace eService.Services.DataServices
{
    public class UserService : IUserService
    {
        private readonly IEfRepository<User> userRepo;
        private readonly ISaveContext context;

        public UserService(IEfRepository<User> userRepo, ISaveContext context)
        {
            this.userRepo = userRepo;
            this.context = context;
        }

        public IQueryable<User> GetAll()
        {
            return this.userRepo.All;
        }

        public IQueryable<User> GetAllAndDeleted()
        {
            return this.userRepo.AllAndDeleted;
        }

        public void Add(User user)
        {
            this.userRepo.Add(user);
            this.context.Commit();
        }

        public void Update(User user)
        {
            this.userRepo.Update(user);
            this.context.Commit();
        }

        public void Delete(User user)
        {
            this.userRepo.Delete(user);
            this.context.Commit();
        }

        public User GetDbModel()
        {
            return new User();
        }
    }
}
