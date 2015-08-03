namespace ReadIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReallyAddedHTMLFieldsToModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "LinkTarget", c => c.String());
            AddColumn("dbo.Posts", "ImageResource", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "ImageResource");
            DropColumn("dbo.Posts", "LinkTarget");
        }
    }
}
