namespace lab5_Jason.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TitleCommentToPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RedditPosts", "Title", c => c.String());
            AddColumn("dbo.RedditPosts", "Text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RedditPosts", "Text");
            DropColumn("dbo.RedditPosts", "Title");
        }
    }
}
