namespace IT_self_service_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactInfoSolution : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Solutions", "ContactInfo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Solutions", "ContactInfo");
        }
    }
}
