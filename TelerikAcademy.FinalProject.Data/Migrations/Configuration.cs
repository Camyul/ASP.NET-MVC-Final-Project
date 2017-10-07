namespace TelerikAcademy.FinalProject.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<TelerikAcademy.FinalProject.Data.MsSqlDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(TelerikAcademy.FinalProject.Data.MsSqlDbContext context)
        {
            this.SeedAdmin(context);

            this.SeedSampleData(context);

            base.Seed(context);
        }

        private void SeedSampleData(MsSqlDbContext context)
        {
            if (!context.Products.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var product = new Product()
                    {
                        Name = "Product " + i,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sit amet lobortis nibh. Nullam bibendum, tortor quis porttitor fringilla, eros risus consequat orci, at scelerisque mauris dolor sit amet nulla. Vivamus turpis lorem, pellentesque eget enim ut, semper faucibus tortor. Aenean malesuada laoreet lorem.",
                        Quantity = i + 3,
                        PictureUrl = "http://www.freepngimg.com/download/special_offer/5-2-special-offer-png-pic.png",
                        CreatedOn = DateTime.Now,
                        Price = 2M
                    };

                    context.Products.Add(product);
                }
            }
        }

        private void SeedAdmin(MsSqlDbContext context)
        {
            // Create admin account
            const string AdministratorUserName = "caves@abv.bg";
            const string AdministratorPassword = "123456";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdministratorUserName, Email = AdministratorUserName, EmailConfirmed = true };
                userManager.Create(user, AdministratorPassword);

                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
