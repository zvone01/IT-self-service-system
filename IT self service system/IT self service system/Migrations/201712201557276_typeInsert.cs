namespace IT_self_service_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typeInsert : DbMigration
    {
        public override void Up()
        {

        //     Sql("INSERT INTO SolutionTypes  (Id, Name) VALUES(1, 'Information request' )");
        //      Sql("INSERT INTO SolutionTypes  (Id, Name) VALUES(2, 'Incident solution request' )");
        //      Sql("INSERT INTO SolutionTypes  (Id, Name) VALUES(3, 'Change  request' )");

            Sql("UPDATE Solutions Set TypeId = 7 WHERE TypeId = NULL");
        }

        public override void Down()
        {
        }
    }
}
