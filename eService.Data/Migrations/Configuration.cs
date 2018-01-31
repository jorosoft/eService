using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using eService.Data.Models;
using eService.Data.Common;

namespace eService.Data.Migrations
{

    public sealed class Configuration : DbMigrationsConfiguration<MsSqlContext>
    {
        private const string AdministratorUserName = "admin";
        private const string AdministratorPassword = "123456";

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MsSqlContext context)
        {
            this.SeedAdmin(context);
            this.SeedData(context);
        }

        private void SeedAdmin(MsSqlContext context)
        {
            if (!context.Roles.Any())
            {
                var roleName = "Admin";
                var secondRoleName = "User";

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = roleName };
                roleManager.Create(role);
                var secondRole = new IdentityRole { Name = secondRoleName };
                roleManager.Create(secondRole);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    EmployeeName = "Администратор",
                    Email = AdministratorUserName + "@eservice.com",
                    EmailConfirmed = true
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, roleName);
            }
        }

        private void SeedData(MsSqlContext context)
        {
            var towns = SeedList.Towns
                .Select(x => new Town
                {
                    Name = x.ToUpper()
                })
                .ToArray();

            context.Towns.AddOrUpdate(x => x.Name, towns);
            context.ServiceTypes.AddOrUpdate(
                x => x.Name, 
                new ServiceType { Code = 0, Name = "Гаранционен" },
                new ServiceType { Code = 1, Name = "Извънгаранционен" } 
                );
            context.Statuses.AddOrUpdate(
                x => x.Name,
                new Status { WorkFlowLevel = 0, Name = "Приет" },
                new Status { WorkFlowLevel = 1, Name = "Изпратен към външен сервиз" },
                new Status { WorkFlowLevel = 9, Name = "Отказана гаранция" },
                new Status { WorkFlowLevel = 9, Name = "Готов" },
                new Status { WorkFlowLevel = 10, Name = "Върнат на клиента" }
                );
        }
    }
}
