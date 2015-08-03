using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RedditClone.Models;
using RedditClone.DAL;

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
            var posts = new List<Post>
            {
            new Post{PostId=1050,Title="This year, I went to comic con as Drunk Uncle Ben. The goal: pass out and die in front of as many spidermen as possible.",UserId=1,Text="Blah de blah", PostTime=DateTime.Today.AddDays(-4)},
            new Post{PostId=4022,Title="What happens when a joey needs a pouch but does not have a mother",UserId=3,Text="Blah de blah", PostTime=DateTime.Today.AddDays(-5)},
            new Post{PostId=4041,Title="Dude surfs a wave on a dirt bike",UserId=3,Text="Blah de blah", PostTime=DateTime.Today.AddDays(-3)},
            new Post{PostId=1045,Title="LPT: Check and replace AC unit filters regularly. Units as clogged as this waste electricity, don't cool as well, and can make you sneeze or sick!",UserId=4,Text="Blah de blah", PostTime=DateTime.Today.AddDays(-7)},
            new Post{PostId=3141,Title="They packaged these water capsules wrong",UserId=6,Text="Blah de blah", PostTime=DateTime.Today.AddDays(-4)},
            new Post{PostId=2021,Title="TIL in 2005, Wells Fargo started a program to educate black communities on building 'generational wealth.' This program turned out to be a front for steering black people into predatory loans. WF paid damages, but not before 100s of houses were foreclosed.",UserId=7,Text="Blah de blah", PostTime=DateTime.Today.AddDays(-2)},
            new Post{PostId=2042,Title="You gotta do what you gotta do.",UserId=7,Text="Blah de blah", PostTime=DateTime.Today}
            };
            posts.ForEach(s => context.Posts.Add(s));
            context.SaveChanges();
           
        }
    }
}