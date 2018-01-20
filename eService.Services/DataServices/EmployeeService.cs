using System.Linq;
using eService.Data.Contracts;
using eService.Data.Models;

namespace eService.Services.DataServices
{
    public class EmployeeService
    {
        private readonly IEfRepository<Employee> employeeRepo;
        private readonly ISaveContext context;

        public EmployeeService(IEfRepository<Employee> employeeRepo, ISaveContext context)
        {
            this.employeeRepo = employeeRepo;
            this.context = context;
        }

        public IQueryable<Employee> GetAll()
        {
            return this.employeeRepo.All;
        }

        public IQueryable<Employee> GetAllAndDeleted()
        {
            return this.employeeRepo.AllAndDeleted;
        }

        public void Add(Employee employee)
        {
            this.employeeRepo.Add(employee);
            this.context.Commit();
        }

        public void Update(Employee employee)
        {
            this.employeeRepo.Update(employee);
            this.context.Commit();
        }

        public void Delete(Employee employee)
        {
            this.employeeRepo.Delete(employee);
            this.context.Commit();
        }

        public Employee GetDbModel()
        {
            return new Employee();
        }
    }
}

