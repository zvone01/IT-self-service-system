namespace IT_self_service_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReputationToSolution : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Solutions", "Reputation", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Solutions", "Reputation");
        }
    }
}
