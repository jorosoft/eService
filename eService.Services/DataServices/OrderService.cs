using System.Linq;
using eService.Data.Contracts;
using eService.Data.Models;
using eService.Services.Contracts;

namespace eService.Services.DataServices
{
    public class OrderService : IOrderService
    {
        private readonly IEfRepository<Order> orderRepo;
        private readonly ISaveContext context;

        public OrderService(IEfRepository<Order> orderRepo, ISaveContext context)
        {
            this.orderRepo = orderRepo;
            this.context = context;
        }

        public IQueryable<Order> GetAll()
        {
            return this.orderRepo.All;
        }

        public IQueryable<Order> GetAllAndDeleted()
        {
            return this.orderRepo.AllAndDeleted;
        }

        public void Add(Order order)
        {
            this.orderRepo.Add(order);
            this.context.Commit();
        }

        public void Update(Order order)
        {
            this.orderRepo.Update(order);
            this.context.Commit();
        }

        public void Delete(Order order)
        {
            this.orderRepo.Delete(order);
            this.context.Commit();
        }

        public Order GetDbModel()
        {
            return new Order();
        }

        public int GetAvailableOrderNumber()
        {
            var lastOrder = this.orderRepo
                .AllAndDeleted
                .OrderByDescending(x => x.Number)
                .FirstOrDefault();

            return lastOrder == null ? 1 : lastOrder.Number;
        }
    }
}

