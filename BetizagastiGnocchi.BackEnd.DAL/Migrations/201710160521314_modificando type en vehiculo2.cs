namespace BetizagastiGnocchi.BackEnd.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificandotypeenvehiculo2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "VehicleType", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "VehicleType", c => c.String());
        }
    }
}
