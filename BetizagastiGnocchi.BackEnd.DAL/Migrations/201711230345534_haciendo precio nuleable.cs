namespace BetizagastiGnocchi.BackEnd.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class haciendoprecionuleable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "sell_Price", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "sell_Price", c => c.Long(nullable: false));
        }
    }
}
