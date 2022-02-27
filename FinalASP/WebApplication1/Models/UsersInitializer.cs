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
        protected override void Seed(ApplicationDbContext context)
        {
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            IdentityRole role1 = new IdentityRole { Name = "admin" };
            IdentityRole role2 = new IdentityRole { Name = "user" };
            roleManager.Create(role1);
            roleManager.Create(role2);

            var admin = new ApplicationUser
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
            base.Seed(context);
        }
    }
}