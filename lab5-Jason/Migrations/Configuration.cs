namespace lab5_Jason.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<lab5_Jason.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(lab5_Jason.Models.ApplicationDbContext context)
        {
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
            context.RedditPosts.AddOrUpdate
                (
                p => p.Name,
                new Models.RedditPost { Name = "Andrew Peters", PostTime = DateTime.Now, Title ="I dont really know what do say" },
                new Models.RedditPost { Name = "Brice Lambson", PostTime = DateTime.Now, Title ="How do you know if your going bald" },
                new Models.RedditPost { Name = "Rowan Miller", PostTime = DateTime.Now, Title ="THE BIG APPLE"}
              );

            context.SaveChanges();
        }
    }
}
