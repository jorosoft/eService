using System.Linq;
using eService.Data.Models;

namespace eService.Services.Contracts
{
    public interface IOrderService
    {
        IQueryable<Order> GetAll();

        IQueryable<Order> GetAllAndDeleted();

        void Add(Order order);

        void Update(Order order);

        void Delete(Order order);

        Order GetDbModel();
    }
}
