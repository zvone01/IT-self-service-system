namespace IT_self_service_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categories : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Categories SET Name = 'Printer' WHERE Id = 1 ");
            Sql("UPDATE Categories SET Name = 'Browser' WHERE Id = 2 ");
            Sql("UPDATE Categories SET Name = 'Windows' WHERE Id = 3 ");
            Sql("DELETE FROM Categories WHERE Id = 4 ");
            Sql("DELETE FROM Categories WHERE Id = 5 ");

        }
        
        public override void Down()
        {
        }
    }
}
