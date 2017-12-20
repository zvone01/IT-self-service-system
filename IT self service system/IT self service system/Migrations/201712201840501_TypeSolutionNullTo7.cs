namespace IT_self_service_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeSolutionNullTo7 : DbMigration
    {
        public override void Up()
        {

            Sql("UPDATE Solutions Set TypeId = 7 WHERE TypeId = NULL ");
        }
        
        public override void Down()
        {
        }
    }
}
