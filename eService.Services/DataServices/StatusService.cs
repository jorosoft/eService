using System.Linq;
using eService.Data.Contracts;
using eService.Data.Models;
using eService.Services.Contracts;

namespace eService.Services.DataServices
{
    public class StatusService : IStatusService
    {
        private readonly IEfRepository<Status> statusRepo;
        private readonly ISaveContext context;

        public StatusService(IEfRepository<Status> statusRepo, ISaveContext context)
        {
            this.statusRepo = statusRepo;
            this.context = context;
        }

        public IQueryable<Status> GetAll()
        {
            return this.statusRepo.All;
        }

        public IQueryable<Status> GetAllAndDeleted()
        {
            return this.statusRepo.AllAndDeleted;
        }

        public void Add(Status status)
        {
            this.statusRepo.Add(status);
            this.context.Commit();
        }

        public void Update(Status status)
        {
            this.statusRepo.Update(status);
            this.context.Commit();
        }

        public void Delete(Status status)
        {
            this.statusRepo.Delete(status);
            this.context.Commit();
        }

        public Status GetDbModel()
        {
            return new Status();
        }
    }
}

