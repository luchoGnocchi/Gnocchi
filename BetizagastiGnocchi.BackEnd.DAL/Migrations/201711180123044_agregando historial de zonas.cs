namespace BetizagastiGnocchi.BackEnd.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandohistorialdezonas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "Zone_Id", "dbo.Zones");
            DropIndex("dbo.Vehicles", new[] { "Zone_Id" });
            CreateTable(
                "dbo.ZoneVehicles",
                c => new
                    {
                        Zone_Id = c.Int(nullable: false),
                        Vehicle_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Zone_Id, t.Vehicle_Id })
                .ForeignKey("dbo.Zones", t => t.Zone_Id, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id, cascadeDelete: true)
                .Index(t => t.Zone_Id)
                .Index(t => t.Vehicle_Id);
            
            DropColumn("dbo.Vehicles", "Zone_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "Zone_Id", c => c.Int());
            DropForeignKey("dbo.ZoneVehicles", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.ZoneVehicles", "Zone_Id", "dbo.Zones");
            DropIndex("dbo.ZoneVehicles", new[] { "Vehicle_Id" });
            DropIndex("dbo.ZoneVehicles", new[] { "Zone_Id" });
            DropTable("dbo.ZoneVehicles");
            CreateIndex("dbo.Vehicles", "Zone_Id");
            AddForeignKey("dbo.Vehicles", "Zone_Id", "dbo.Zones", "Id");
        }
    }
}
