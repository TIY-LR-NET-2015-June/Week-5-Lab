namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "UpVotes", c => c.Int());
            AlterColumn("dbo.Articles", "DownVotes", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "DownVotes", c => c.Int(nullable: false));
            AlterColumn("dbo.Articles", "UpVotes", c => c.Int(nullable: false));
        }
    }
}
