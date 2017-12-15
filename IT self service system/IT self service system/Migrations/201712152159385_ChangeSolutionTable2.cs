namespace IT_self_service_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSolutionTable2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Solutions", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Solutions", "Description", c => c.Boolean(nullable: false));
        }
    }
}
