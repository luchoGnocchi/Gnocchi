namespace BetizagastiGnocchi.BackEnd.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandohoraaMovimientozona : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleMovements", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleMovements", "Time", c => c.Int(nullable: false));
        }
    }
}
