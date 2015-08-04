namespace Reddit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndividualVoteIncrimients : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PositiveVote", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "NegativeVote", c => c.Int(nullable: false));
            DropColumn("dbo.Posts", "ConsolidatedVotes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "ConsolidatedVotes", c => c.Int(nullable: false));
            DropColumn("dbo.Posts", "NegativeVote");
            DropColumn("dbo.Posts", "PositiveVote");
        }
    }
}
