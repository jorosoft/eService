using System.Linq;
using eService.Data.Contracts;
using eService.Data.Models;
using eService.Services.Contracts;

namespace eService.Services.DataServices
{
    public class HistoryService : IHistoryService
    {
        private readonly IEfRepository<History> historyRepo;
        private readonly ISaveContext context;

        public HistoryService(IEfRepository<History> historyRepo, ISaveContext context)
        {
            this.historyRepo = historyRepo;
            this.context = context;
        }

        public IQueryable<History> GetAll()
        {
            return this.historyRepo.All;
        }

        public IQueryable<History> GetAllAndDeleted()
        {
            return this.historyRepo.AllAndDeleted;
        }

        public void Add(History history)
        {
            this.historyRepo.Add(history);
            this.context.Commit();
        }

        public void Update(History history)
        {
            this.historyRepo.Update(history);
            this.context.Commit();
        }

        public void Delete(History history)
        {
            this.historyRepo.Delete(history);
            this.context.Commit();
        }

        public History GetDbModel()
        {
            return new History();
        }
    }
}

