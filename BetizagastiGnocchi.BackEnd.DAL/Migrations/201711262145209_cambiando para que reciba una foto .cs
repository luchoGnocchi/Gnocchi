namespace BetizagastiGnocchi.BackEnd.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiandoparaquerecibaunafoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DamageRegistries", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DamageRegistries", "Image");
        }
    }
}
