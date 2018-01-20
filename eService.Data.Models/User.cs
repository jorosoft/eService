using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using eService.Data.Models.Contracts;

namespace eService.Data.Models
{
    public class User : IdentityUser, IDeletable
    {
        private ICollection<Employee> employees;

        public User()
        {
            this.employees = new HashSet<Employee>();
        }
        
        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Employee> Employees
        {
            get
            {
                return this.employees;
            }

            set
            {
                this.employees = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
