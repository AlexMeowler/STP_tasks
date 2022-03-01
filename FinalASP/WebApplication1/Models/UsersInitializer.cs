using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        public override void InitializeDatabase(ApplicationDbContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }
        protected override void Seed(ApplicationDbContext context)
        {
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            IdentityRole role1 = new IdentityRole { Name = "admin" };
            IdentityRole role2 = new IdentityRole { Name = "user" };
            roleManager.Create(role1);
            roleManager.Create(role2);

            ApplicationUser admin = new ApplicationUser
            {
                Email = "admin@mail.ru",
                UserName = "admin@mail.ru"
            };
            string password = "qwerty";
            IdentityResult result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }

            ApplicationUser user = new ApplicationUser
            {
                Email = "user@mail.ru",
                UserName = "user@mail.ru"
            };
            result = userManager.Create(user, password);
            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, role2.Name);
            }
            base.Seed(context);
        }
    }
}