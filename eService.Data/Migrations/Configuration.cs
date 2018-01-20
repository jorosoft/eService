using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using eService.Data.Models;

namespace eService.Data.Migrations
{   

    public sealed class Configuration : DbMigrationsConfiguration<MsSqlContext>
    {
        private const string AdministratorUserName = "admin@eservice.com";
        private const string AdministratorPassword = "admina";

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MsSqlContext context)
        {
            this.SeedAdmin(context);
        }

        private void SeedAdmin(MsSqlContext context)
        {
            if (!context.Roles.Any())
            {
                var roleName = "Admin";

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = roleName };
                roleManager.Create(role);
                
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, roleName);
            }
        }
    }
}
