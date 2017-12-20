namespace IT_self_service_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class solutionType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SolutionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
            DropTable("dbo.SolutionTypes");
        }
    }
}
