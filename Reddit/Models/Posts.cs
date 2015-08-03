namespace Reddit.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Reddit.Models;

    public partial class Posts : DbContext
    {
        public Posts()
            : base("Posts")
        {

            Database.SetInitializer<Posts>(new CreateDatabaseIfNotExists<Posts>());

        }
        public virtual DbSet<Post> RedditDB { get; set; }
    }
}
