namespace BetizagastiGnocchi.BackEnd.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandomovimientosdezonas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ZoneVehicles", "Zone_Id", "dbo.Zones");
            DropForeignKey("dbo.ZoneVehicles", "Vehicle_Id", "dbo.Vehicles");
            DropIndex("dbo.ZoneVehicles", new[] { "Zone_Id" });
            DropIndex("dbo.ZoneVehicles", new[] { "Vehicle_Id" });
            AddColumn("dbo.Vehicles", "ZoneId", c => c.Int());
            CreateIndex("dbo.Vehicles", "ZoneId");
            AddForeignKey("dbo.Vehicles", "ZoneId", "dbo.Zones", "Id");
            DropTable("dbo.ZoneVehicles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ZoneVehicles",
                c => new
                    {
                        Zone_Id = c.Int(nullable: false),
                        Vehicle_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Zone_Id, t.Vehicle_Id });
            
            DropForeignKey("dbo.Vehicles", "ZoneId", "dbo.Zones");
            DropIndex("dbo.Vehicles", new[] { "ZoneId" });
            DropColumn("dbo.Vehicles", "ZoneId");
            CreateIndex("dbo.ZoneVehicles", "Vehicle_Id");
            CreateIndex("dbo.ZoneVehicles", "Zone_Id");
            AddForeignKey("dbo.ZoneVehicles", "Vehicle_Id", "dbo.Vehicles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ZoneVehicles", "Zone_Id", "dbo.Zones", "Id", cascadeDelete: true);
        }
    }
}
