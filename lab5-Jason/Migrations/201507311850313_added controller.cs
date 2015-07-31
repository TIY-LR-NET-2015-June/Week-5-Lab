namespace lab5_Jason.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcontroller : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RedditPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UpVote = c.Int(nullable: false),
                        DownVote = c.Int(nullable: false),
                        PostTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RedditPosts");
        }
    }
}
