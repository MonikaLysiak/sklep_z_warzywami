namespace SklepZWarzywami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class connectingSprzedawca_Zakup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Warzywoes", "IloscNaStanie", c => c.Double(nullable: false));
            AddColumn("dbo.Zakups", "SprzedawcaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Zakups", "SprzedawcaId");
            AddForeignKey("dbo.Zakups", "SprzedawcaId", "dbo.Sprzedawcas", "SprzedawcaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zakups", "SprzedawcaId", "dbo.Sprzedawcas");
            DropIndex("dbo.Zakups", new[] { "SprzedawcaId" });
            DropColumn("dbo.Zakups", "SprzedawcaId");
            DropColumn("dbo.Warzywoes", "IloscNaStanie");
        }
    }
}
