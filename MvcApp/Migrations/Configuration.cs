namespace MvcApp.Migrations
{
    using MvcApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcApp.Models.DemoMvDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcApp.Models.DemoMvDb context)
        {
            
            context.Movies.AddOrUpdate(r => r.Name,
              new Movie { Name = "Avatar", Category = "SciFi", YearOfRelease = 2010 },
              new Movie { Name = "After Earth", Category = "SciFi", YearOfRelease = 2013 },
              new Movie { Name = "Shutter Island", Category = "Thriller", YearOfRelease = 2007 },
              new Movie
              {
                  Name = "Casino Royale",
                  Category = "Action",
                  YearOfRelease = 2009,
                  Reviews =
                  new List<MovieReview> {
                    new MovieReview{Review=9, ReviewerName="Bob",Body="Good action movie!"}
                
                }
              });

            SeedMemberShip();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private void SeedMemberShip()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }

            if (membership.GetUser("bob",false)==null)
            {
                membership.CreateUserAndAccount("bob", "welcome123");
            }
            if (!roles.GetRolesForUser("bob").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "bob" }, new[] { "admin" });
            }
        }
    }
}
