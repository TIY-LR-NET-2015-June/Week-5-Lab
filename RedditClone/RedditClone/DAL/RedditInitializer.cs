using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RedditClone.Models;
using RedditClone.DAL;
using System.Data.Entity.Migrations;

namespace RedditClone.DAL
{
    public class RedditInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RedditContext>
    {
        protected override void Seed(RedditContext context)
        {
            var users = new List<User>
            {
            new User{FirstName="Carson",LastName="Alexander",UserName="calexander"},
            new User{FirstName="Meredith",LastName="Alonso",UserName="malonso"},
            new User{FirstName="Arturo",LastName="Anand",UserName="aanand"},
            new User{FirstName="Gytis",LastName="Barzdukas",UserName="gbarzdukas"},
            new User{FirstName="Yan",LastName="Li",UserName="yli"},
            new User{FirstName="Peggy",LastName="Justice",UserName="pjustice"},
            new User{FirstName="Laura",LastName="Norman",UserName="lnorman"},
            new User{FirstName="Nino",LastName="Olivetto",UserName="nolivetto"}
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            context.Posts.AddOrUpdate(x => x.Title,
            new Post { Title = "This year, I went to comic con as Drunk Uncle Ben. The goal: pass out and die in front of as many spidermen as possible.", UserId = 1, Text = "Blah de blah", PostTime = DateTime.Today.AddDays(-4) },
            new Post { Title = "What happens when a joey needs a pouch but does not have a mother", UserId = 3, Text = "Blah de blah", PostTime = DateTime.Today.AddDays(-5) },
            new Post { Title = "Dude surfs a wave on a dirt bike", UserId = 3, Text = "Blah de blah", PostTime = DateTime.Today.AddDays(-3) },
            new Post { Title = "LPT: Check and replace AC unit filters regularly. Units as clogged as this waste electricity, don't cool as well, and can make you sneeze or sick!", UserId = 4, Text = "Blah de blah", PostTime = DateTime.Today.AddDays(-7) },
            new Post { Title = "They packaged these water capsules wrong", UserId = 6, Text = "Blah de blah", PostTime = DateTime.Today.AddDays(-4) },
            new Post { Title = "TIL in 2005, Wells Fargo started a program to educate black communities on building 'generational wealth.' This program turned out to be a front for steering black people into predatory loans. WF paid damages, but not before 100s of houses were foreclosed.", UserId = 7, Text = "Blah de blah", PostTime = DateTime.Today.AddDays(-2) },
            new Post { Title = "You gotta do what you gotta do.", UserId = 7, Text = "Blah de blah", PostTime = DateTime.Today }
            );
            context.SaveChanges();

        }
    }
}