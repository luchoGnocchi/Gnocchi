namespace BetizagastiGnocchi.BackEnd.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandoreadytobuyenvehiculo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "readyToBuy", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "readyToBuy");
        }
    }
}
