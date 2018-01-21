using System.Linq;
using eService.Data.Models;

namespace eService.Services.Contracts
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetAll();

        IQueryable<Employee> GetAllAndDeleted();

        void Add(Employee employee);

        void Update(Employee employee);

        void Delete(Employee employee);

        Employee GetDbModel();
    }
}
