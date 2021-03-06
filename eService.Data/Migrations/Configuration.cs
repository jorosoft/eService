using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using eService.Data.Models;

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
                    EmployeeName = "�������������",
                    Email = AdministratorUserName + "@eservice.com",
                    EmailConfirmed = true
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, roleName);
            }
        }

        private void SeedData(MsSqlContext context)
        {
            //var towns = File.ReadAllText("./eService.Data/Common/towns.csv")
            //    .Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(x => new Town
            //    {
            //        Name = x
            //    })
            //    .ToArray();

            //var villages = File.ReadAllText("./eService.Data/Common/villages.csv")
            //    .Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(x => new Town
            //    {
            //        Name = x
            //    })
            //    .ToArray();

            //context.Towns.AddOrUpdate(x => x.Name, towns);
            //context.Towns.AddOrUpdate(x => x.Name, villages);

            context.Statuses.AddOrUpdate(
                x => x.Name,
                new Status { WorkFlowLevel = 0, Name = "�����" },
                new Status { WorkFlowLevel = 1, Name = "�������� ��� ������ ������" },
                new Status { WorkFlowLevel = 9, Name = "�������� ��������" },
                new Status { WorkFlowLevel = 9, Name = "�����" },
                new Status { WorkFlowLevel = 10, Name = "������ �� �������" }
                );
        }
    }
}
