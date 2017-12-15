namespace IT_self_service_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSolution1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Solutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Description = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        CreatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.CreatedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Solutions", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solutions", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Solutions", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Solutions", new[] { "CategoryId" });
            DropTable("dbo.Solutions");
        }
    }
}
