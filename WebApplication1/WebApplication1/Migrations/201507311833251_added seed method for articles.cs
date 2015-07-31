namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedseedmethodforarticles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Submitted = c.DateTime(nullable: false),
                        Headline = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        PictureUrl = c.String(),
                        UpVotes = c.Int(nullable: false),
                        DownVotes = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Articles", new[] { "User_Id" });
            DropTable("dbo.Articles");
        }
    }
}
