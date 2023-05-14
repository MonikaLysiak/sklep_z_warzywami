namespace SklepZWarzywami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ZakupJednostkowies", "SprzedawcaId", "dbo.Sprzedawcas");
            DropForeignKey("dbo.Zakups", "SprzedawcaId", "dbo.Sprzedawcas");
            DropIndex("dbo.Zakups", new[] { "SprzedawcaId" });
            DropIndex("dbo.ZakupJednostkowies", new[] { "SprzedawcaId" });
            AddColumn("dbo.Sprzedawcas", "ZakupId", c => c.Int());
            AddColumn("dbo.Sprzedawcas", "Zakup_ZakupId", c => c.Int());
            AddColumn("dbo.Zakups", "KwotaCalkowita", c => c.Double(nullable: false));
            AddColumn("dbo.Zakups", "Sprzedawca_SprzedawcaId", c => c.Int());
            AddColumn("dbo.Zakups", "Sprzedawca_SprzedawcaId1", c => c.Int());
            AddColumn("dbo.ZakupJednostkowies", "Cena", c => c.Double(nullable: false));
            AlterColumn("dbo.Zakups", "SprzedawcaId", c => c.Int());
            CreateIndex("dbo.Sprzedawcas", "Zakup_ZakupId");
            CreateIndex("dbo.Zakups", "Sprzedawca_SprzedawcaId");
            CreateIndex("dbo.Zakups", "Sprzedawca_SprzedawcaId1");
            AddForeignKey("dbo.Zakups", "Sprzedawca_SprzedawcaId", "dbo.Sprzedawcas", "SprzedawcaId");
            AddForeignKey("dbo.Sprzedawcas", "Zakup_ZakupId", "dbo.Zakups", "ZakupId");
            AddForeignKey("dbo.Zakups", "Sprzedawca_SprzedawcaId1", "dbo.Sprzedawcas", "SprzedawcaId");
            DropColumn("dbo.ZakupJednostkowies", "SprzedawcaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ZakupJednostkowies", "SprzedawcaId", c => c.Int());
            DropForeignKey("dbo.Zakups", "Sprzedawca_SprzedawcaId1", "dbo.Sprzedawcas");
            DropForeignKey("dbo.Sprzedawcas", "Zakup_ZakupId", "dbo.Zakups");
            DropForeignKey("dbo.Zakups", "Sprzedawca_SprzedawcaId", "dbo.Sprzedawcas");
            DropIndex("dbo.Zakups", new[] { "Sprzedawca_SprzedawcaId1" });
            DropIndex("dbo.Zakups", new[] { "Sprzedawca_SprzedawcaId" });
            DropIndex("dbo.Sprzedawcas", new[] { "Zakup_ZakupId" });
            AlterColumn("dbo.Zakups", "SprzedawcaId", c => c.Int(nullable: false));
            DropColumn("dbo.ZakupJednostkowies", "Cena");
            DropColumn("dbo.Zakups", "Sprzedawca_SprzedawcaId1");
            DropColumn("dbo.Zakups", "Sprzedawca_SprzedawcaId");
            DropColumn("dbo.Zakups", "KwotaCalkowita");
            DropColumn("dbo.Sprzedawcas", "Zakup_ZakupId");
            DropColumn("dbo.Sprzedawcas", "ZakupId");
            CreateIndex("dbo.ZakupJednostkowies", "SprzedawcaId");
            CreateIndex("dbo.Zakups", "SprzedawcaId");
            AddForeignKey("dbo.Zakups", "SprzedawcaId", "dbo.Sprzedawcas", "SprzedawcaId", cascadeDelete: true);
            AddForeignKey("dbo.ZakupJednostkowies", "SprzedawcaId", "dbo.Sprzedawcas", "SprzedawcaId");
        }
    }
}
