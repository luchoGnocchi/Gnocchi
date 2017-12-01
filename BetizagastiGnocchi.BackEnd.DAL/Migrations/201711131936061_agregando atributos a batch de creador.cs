namespace BetizagastiGnocchi.BackEnd.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregandoatributosabatchdecreador : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Batches", name: "Creator_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Batches", name: "IX_Creator_Id", newName: "IX_User_Id");
            AddColumn("dbo.Batches", "UserdId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Batches", "UserdId");
            RenameIndex(table: "dbo.Batches", name: "IX_User_Id", newName: "IX_Creator_Id");
            RenameColumn(table: "dbo.Batches", name: "User_Id", newName: "Creator_Id");
        }
    }
}
