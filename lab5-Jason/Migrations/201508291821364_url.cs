namespace lab5_Jason.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class url : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RedditPosts", "URL", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RedditPosts", "URL");
        }
    }
}
