namespace BetizagastiGnocchi.BackEnd.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class batchtransportFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Batches", "BatchTransport_Id", "dbo.BatchTransports");
            DropIndex("dbo.Batches", new[] { "BatchTransport_Id" });
            AlterColumn("dbo.Batches", "BatchTransport_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Batches", "BatchTransport_Id");
            AddForeignKey("dbo.Batches", "BatchTransport_Id", "dbo.BatchTransports", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Batches", "BatchTransport_Id", "dbo.BatchTransports");
            DropIndex("dbo.Batches", new[] { "BatchTransport_Id" });
            AlterColumn("dbo.Batches", "BatchTransport_Id", c => c.Int());
            CreateIndex("dbo.Batches", "BatchTransport_Id");
            AddForeignKey("dbo.Batches", "BatchTransport_Id", "dbo.BatchTransports", "Id");
        }
    }
}
