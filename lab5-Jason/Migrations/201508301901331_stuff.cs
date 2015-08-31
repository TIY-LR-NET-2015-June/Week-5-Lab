namespace lab5_Jason.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RedditPosts", "URL", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RedditPosts", "URL", c => c.Binary());
        }
    }
}
