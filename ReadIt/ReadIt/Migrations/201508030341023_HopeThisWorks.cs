namespace ReadIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HopeThisWorks : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "Author_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Posts", name: "IX_Author_Id", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Posts", name: "IX_User_Id", newName: "IX_Author_Id");
            RenameColumn(table: "dbo.Posts", name: "User_Id", newName: "Author_Id");
        }
    }
}
