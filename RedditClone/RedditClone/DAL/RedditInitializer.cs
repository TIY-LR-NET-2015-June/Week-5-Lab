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
            new Post{PostId=1050,Title="Chemistry",UserId=1,Text="Blah de blah", PostTime=DateTime.Today.AddDays(-4)},
            new Post{PostId=4022,Title="Microeconomics",UserId=3,Text="Blah de blah", PostTime=DateTime.Today.AddDays(-5)},
            new Post{PostId=4041,Title="Macroeconomics",UserId=3,Text="Blah de blah", PostTime=DateTime.Today.AddDays(-3)},
            new Post{PostId=1045,Title="Calculus",UserId=4,Text="Blah de blah", PostTime=DateTime.Today.AddDays(-7)},
            new Post{PostId=3141,Title="Trigonometry",UserId=6,Text="Blah de blah", PostTime=DateTime.Today.AddDays(-4)},
            new Post{PostId=2021,Title="Composition",UserId=7,Text="Blah de blah", PostTime=DateTime.Today.AddDays(-2)},
            new Post{PostId=2042,Title="Literature",UserId=7,Text="Blah de blah", PostTime=DateTime.Today}
            };
            posts.ForEach(s => context.Posts.Add(s));
            context.SaveChanges();
           
        }
    }
}