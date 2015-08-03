namespace RedditClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpAndDownVote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "UpVotes", c => c.Int(nullable: false,defaultValue:0));
            AddColumn("dbo.Post", "DownVotes", c => c.Int(nullable: false,defaultValue:0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Post", "DownVotes");
            DropColumn("dbo.Post", "UpVotes");
        }
    }
}
