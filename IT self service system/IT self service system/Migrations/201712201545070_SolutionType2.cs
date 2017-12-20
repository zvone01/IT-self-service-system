namespace IT_self_service_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SolutionType2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Solutions", "TypeId", c => c.Int(nullable: true));
            CreateIndex("dbo.Solutions", "TypeId");
            AddForeignKey("dbo.Solutions", "TypeId", "dbo.SolutionTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Solutions", "TypeId", "dbo.SolutionTypes");
            DropIndex("dbo.Solutions", new[] { "TypeId" });
            DropColumn("dbo.Solutions", "TypeId");
        }
    }
}
