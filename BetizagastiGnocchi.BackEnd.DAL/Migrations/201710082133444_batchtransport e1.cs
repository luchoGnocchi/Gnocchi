namespace BetizagastiGnocchi.BackEnd.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class batchtransporte1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRols",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UType = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Creator_Id = c.Int(),
                        BatchTransport_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Creator_Id)
                .ForeignKey("dbo.BatchTransports", t => t.BatchTransport_Id)
                .Index(t => t.Creator_Id)
                .Index(t => t.BatchTransport_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Token = c.Guid(nullable: false),
                        Rol_Id = c.Int(nullable: false),
                        Salt = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserRols", t => t.Rol_Id, cascadeDelete: true)
                .Index(t => t.Rol_Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        BatchId = c.Int(),
                        Color = c.String(),
                        VehicleType = c.String(),
                        VIN = c.String(),
                        Zone_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId)
                .ForeignKey("dbo.Zones", t => t.Zone_Id)
                .Index(t => t.BatchId)
                .Index(t => t.Zone_Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaceInMoment = c.Short(nullable: false),
                        CurrentDate = c.DateTime(nullable: false),
                        Vehicle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .Index(t => t.Vehicle_Id);
            
            CreateTable(
                "dbo.Inspections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Short(nullable: false),
                        DateAndTime = c.DateTime(nullable: false),
                        Place = c.Short(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        Inspector_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Inspector_Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.Inspector_Id);
            
            CreateTable(
                "dbo.DamageRegistries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Inspection_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inspections", t => t.Inspection_Id)
                .Index(t => t.Inspection_Id);
            
            CreateTable(
                "dbo.BatchTransports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        Transporter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Transporter_Id)
                .Index(t => t.Transporter_Id);
            
            CreateTable(
                "dbo.VehicleMovements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.Int(nullable: false),
                        DestinationZone_Id = c.Int(),
                        OriginZone_Id = c.Int(),
                        User_Id = c.Int(),
                        Vehicle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zones", t => t.DestinationZone_Id)
                .ForeignKey("dbo.Zones", t => t.OriginZone_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .Index(t => t.DestinationZone_Id)
                .Index(t => t.OriginZone_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Vehicle_Id);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MaxCapacity = c.Int(nullable: false),
                        UsedCapacity = c.Int(nullable: false),
                        Zone_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zones", t => t.Zone_Id)
                .Index(t => t.Zone_Id);
            
            CreateTable(
                "dbo.UserRolActionOperations",
                c => new
                    {
                        UserRol_Id = c.Int(nullable: false),
                        ActionOperation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserRol_Id, t.ActionOperation_Id })
                .ForeignKey("dbo.UserRols", t => t.UserRol_Id, cascadeDelete: true)
                .ForeignKey("dbo.ActionOperations", t => t.ActionOperation_Id, cascadeDelete: true)
                .Index(t => t.UserRol_Id)
                .Index(t => t.ActionOperation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleMovements", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.VehicleMovements", "User_Id", "dbo.Users");
            DropForeignKey("dbo.VehicleMovements", "OriginZone_Id", "dbo.Zones");
            DropForeignKey("dbo.VehicleMovements", "DestinationZone_Id", "dbo.Zones");
            DropForeignKey("dbo.Vehicles", "Zone_Id", "dbo.Zones");
            DropForeignKey("dbo.Zones", "Zone_Id", "dbo.Zones");
            DropForeignKey("dbo.BatchTransports", "Transporter_Id", "dbo.Users");
            DropForeignKey("dbo.Batches", "BatchTransport_Id", "dbo.BatchTransports");
            DropForeignKey("dbo.Inspections", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Inspections", "Inspector_Id", "dbo.Users");
            DropForeignKey("dbo.DamageRegistries", "Inspection_Id", "dbo.Inspections");
            DropForeignKey("dbo.States", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Batches", "Creator_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Rol_Id", "dbo.UserRols");
            DropForeignKey("dbo.UserRolActionOperations", "ActionOperation_Id", "dbo.ActionOperations");
            DropForeignKey("dbo.UserRolActionOperations", "UserRol_Id", "dbo.UserRols");
            DropIndex("dbo.UserRolActionOperations", new[] { "ActionOperation_Id" });
            DropIndex("dbo.UserRolActionOperations", new[] { "UserRol_Id" });
            DropIndex("dbo.Zones", new[] { "Zone_Id" });
            DropIndex("dbo.VehicleMovements", new[] { "Vehicle_Id" });
            DropIndex("dbo.VehicleMovements", new[] { "User_Id" });
            DropIndex("dbo.VehicleMovements", new[] { "OriginZone_Id" });
            DropIndex("dbo.VehicleMovements", new[] { "DestinationZone_Id" });
            DropIndex("dbo.BatchTransports", new[] { "Transporter_Id" });
            DropIndex("dbo.DamageRegistries", new[] { "Inspection_Id" });
            DropIndex("dbo.Inspections", new[] { "Inspector_Id" });
            DropIndex("dbo.Inspections", new[] { "VehicleId" });
            DropIndex("dbo.States", new[] { "Vehicle_Id" });
            DropIndex("dbo.Vehicles", new[] { "Zone_Id" });
            DropIndex("dbo.Vehicles", new[] { "BatchId" });
            DropIndex("dbo.Users", new[] { "Rol_Id" });
            DropIndex("dbo.Batches", new[] { "BatchTransport_Id" });
            DropIndex("dbo.Batches", new[] { "Creator_Id" });
            DropTable("dbo.UserRolActionOperations");
            DropTable("dbo.Zones");
            DropTable("dbo.VehicleMovements");
            DropTable("dbo.BatchTransports");
            DropTable("dbo.DamageRegistries");
            DropTable("dbo.Inspections");
            DropTable("dbo.States");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Users");
            DropTable("dbo.Batches");
            DropTable("dbo.UserRols");
            DropTable("dbo.ActionOperations");
        }
    }
}
