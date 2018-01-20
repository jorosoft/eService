using System.Data.Entity;
using eService.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eService.Data
{
    public class MsSqlContext : IdentityDbContext<User>
    {
        public MsSqlContext()
            : base("eServiceConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Client> Clients { get; set; }

        public IDbSet<Employee> Employees { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<ServiceType> ServiceTypes { get; set; }

        public IDbSet<Street> Streets { get; set; }

        public IDbSet<Address> Addresses { get; set; }

        public IDbSet<Supplier> Suppliers { get; set; }

        public IDbSet<Status> Statuses { get; set; }
    }
}
