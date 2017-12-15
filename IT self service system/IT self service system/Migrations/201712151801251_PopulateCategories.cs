namespace IT_self_service_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories ( Name) VALUES ('Category 1')");
            Sql("INSERT INTO Categories ( Name) VALUES ('Category 2')");
            Sql("INSERT INTO Categories ( Name) VALUES ('Category 3')");
            Sql("INSERT INTO Categories ( Name) VALUES ('Category 4')");
            Sql("INSERT INTO Categories ( Name) VALUES ('Category 5')");
        }
        
        public override void Down()
        {
        }
    }
}
