namespace BetizagastiGnocchi.BackEnd.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandonavecacionentrebatchybatchtransport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BatchTransports", "UserdId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BatchTransports", "UserdId");
        }
    }
}
