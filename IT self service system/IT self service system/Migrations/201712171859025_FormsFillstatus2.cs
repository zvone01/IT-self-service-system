namespace IT_self_service_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormsFillstatus2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        Comment = c.String(),
                        UserId = c.String(maxLength: 128),
                        SolutionId = c.Int(nullable: false),
                        StatusId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Solutions", t => t.SolutionId, cascadeDelete: true)
                .ForeignKey("dbo.FormStatus", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.SolutionId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.FormStatus",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

             Sql("INSERT INTO FormStatus VALUES('New')");
               Sql("INSERT INTO FormStatus VALUES('In Process')");
               Sql("INSERT INTO FormStatus VALUES('Finished')");

        }

        public override void Down()
        {
            DropForeignKey("dbo.Forms", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Forms", "StatusId", "dbo.FormStatus");
            DropForeignKey("dbo.Forms", "SolutionId", "dbo.Solutions");
            DropIndex("dbo.Forms", new[] { "StatusId" });
            DropIndex("dbo.Forms", new[] { "SolutionId" });
            DropIndex("dbo.Forms", new[] { "UserId" });
            DropTable("dbo.FormStatus");
            DropTable("dbo.Forms");
        }
    }
}
