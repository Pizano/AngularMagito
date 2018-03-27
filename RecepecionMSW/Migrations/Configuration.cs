namespace RecepecionMSW.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RecepecionMSW.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            // Jr
            // Se hablita en true si se necesita que se creen en ejecucion de la App la insercion de usuarios y roles.
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RecepecionMSW.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppAdmin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "AppUser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppUser" };

                manager.Create(role);
            }
            // Se crea vel usuario administrador de la aplicación
            if (!context.Users.Any(u => u.UserName == "administrador"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "administrador" };

                manager.Create(user, "okm265IJN");
                manager.AddToRole(user.Id, "AppAdmin");
            }
            
        }
    }
}
