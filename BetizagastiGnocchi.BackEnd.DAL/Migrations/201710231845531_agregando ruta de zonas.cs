namespace BetizagastiGnocchi.BackEnd.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandorutadezonas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RouteZones",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        ZonesToPass = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RouteZones");
        }
    }
}
