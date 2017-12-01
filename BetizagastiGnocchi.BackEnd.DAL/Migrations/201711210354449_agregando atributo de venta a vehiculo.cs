namespace BetizagastiGnocchi.BackEnd.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandoatributodeventaavehiculo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "SellId", c => c.Int());
            AddColumn("dbo.Vehicles", "sell_Name", c => c.String());
            AddColumn("dbo.Vehicles", "sell_Surname", c => c.String());
            AddColumn("dbo.Vehicles", "sell_Telephone", c => c.String());
            AddColumn("dbo.Vehicles", "sell_Price", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "sell_Price");
            DropColumn("dbo.Vehicles", "sell_Telephone");
            DropColumn("dbo.Vehicles", "sell_Surname");
            DropColumn("dbo.Vehicles", "sell_Name");
            DropColumn("dbo.Vehicles", "SellId");
        }
    }
}
