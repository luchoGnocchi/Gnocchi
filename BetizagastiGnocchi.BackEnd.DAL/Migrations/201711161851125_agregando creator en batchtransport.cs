namespace BetizagastiGnocchi.BackEnd.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandocreatorenbatchtransport : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BatchTransports", new[] { "Transporter_Id" });
            DropColumn("dbo.BatchTransports", "UserdId");
            RenameColumn(table: "dbo.BatchTransports", name: "Transporter_Id", newName: "UserdId");
            AddColumn("dbo.BatchTransports", "CreatorUserId", c => c.Int());
            AlterColumn("dbo.BatchTransports", "UserdId", c => c.Int());
            CreateIndex("dbo.BatchTransports", "UserdId");
            CreateIndex("dbo.BatchTransports", "CreatorUserId");
            AddForeignKey("dbo.BatchTransports", "CreatorUserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BatchTransports", "CreatorUserId", "dbo.Users");
            DropIndex("dbo.BatchTransports", new[] { "CreatorUserId" });
            DropIndex("dbo.BatchTransports", new[] { "UserdId" });
            AlterColumn("dbo.BatchTransports", "UserdId", c => c.Int(nullable: false));
            DropColumn("dbo.BatchTransports", "CreatorUserId");
            RenameColumn(table: "dbo.BatchTransports", name: "UserdId", newName: "Transporter_Id");
            AddColumn("dbo.BatchTransports", "UserdId", c => c.Int(nullable: false));
            CreateIndex("dbo.BatchTransports", "Transporter_Id");
        }
    }
}
