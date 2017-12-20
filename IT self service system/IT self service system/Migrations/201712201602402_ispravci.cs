namespace IT_self_service_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ispravci : DbMigration
    {
        public override void Up()
        {
        
            Sql("UPDATE Solutions Set TypeId = 1 WHERE TypeId = NULL ");
        }
        
        public override void Down()
        {
        }
    }
}
