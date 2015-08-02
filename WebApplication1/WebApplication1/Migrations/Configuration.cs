namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication1.Models.ApplicationDbContext context)
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

            context.Articles.AddOrUpdate(x => x.Headline,
      new Article() { Headline = "A linguist peeks into your math brain", Url = "https://mknull.wordpress.com/2015/06/10/a-linguist-peeks-into-your-math-brain/", Submitted = DateTime.Now, PictureUrl = "https://mknull.files.wordpress.com/2015/06/math-brain.jpeg?w=300&h=225"},
      new Article() { Headline = "Consumers should push back against sleazy business practices", Url = "https://mknull.wordpress.com/2015/02/26/consumers-should-push-back-against-sleazy-business-practices/", Submitted=DateTime.Now },
      new Article() { Headline = "On Being a Cat Person", Url = "https://mknull.wordpress.com/2014/12/28/on-being-a-cat-person/", Submitted=DateTime.Now , PictureUrl= "https://mknull.files.wordpress.com/2014/12/1947994_10203065143007003_1919646954_n.jpg?w=300&h=225" },
      new Article() { Headline = "Candy Bars Used To Be A Nickel, But Not Today's Nickel", Url = "https://mknull.wordpress.com/2014/12/23/candy-bars-used-to-be-a-nickel-but-not-todays-nickel/", Submitted=DateTime.Now , PictureUrl = "https://mknull.files.wordpress.com/2014/12/screen-shot-2014-12-23-at-5-11-56-pm.png?w=288&h=300"}
      );
        }
    }
}
