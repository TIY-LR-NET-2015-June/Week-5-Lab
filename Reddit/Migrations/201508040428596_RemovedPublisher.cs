namespace Reddit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedPublisher : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "Publisher");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Publisher", c => c.String());
        }
    }
}
