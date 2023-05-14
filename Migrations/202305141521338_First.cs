namespace SklepZWarzywami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sprzedawcas",
                c => new
                    {
                        SprzedawcaId = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                    })
                .PrimaryKey(t => t.SprzedawcaId);
            
            CreateTable(
                "dbo.Zakups",
                c => new
                    {
                        ZakupId = c.Int(nullable: false, identity: true),
                        SprzedawcaId = c.Int(nullable: false),
                        ZakupJednostkowyId = c.Int(),
                    })
                .PrimaryKey(t => t.ZakupId)
                .ForeignKey("dbo.ZakupJednostkowies", t => t.ZakupJednostkowyId)
                .ForeignKey("dbo.Sprzedawcas", t => t.SprzedawcaId, cascadeDelete: true)
                .Index(t => t.SprzedawcaId)
                .Index(t => t.ZakupJednostkowyId);
            
            CreateTable(
                "dbo.ZakupJednostkowies",
                c => new
                    {
                        ZakupJednostkowyId = c.Int(nullable: false, identity: true),
                        Ilosc = c.Double(nullable: false),
                        WarzywoId = c.Int(),
                        SprzedawcaId = c.Int(),
                    })
                .PrimaryKey(t => t.ZakupJednostkowyId)
                .ForeignKey("dbo.Sprzedawcas", t => t.SprzedawcaId)
                .ForeignKey("dbo.Warzywoes", t => t.WarzywoId)
                .Index(t => t.WarzywoId)
                .Index(t => t.SprzedawcaId);
            
            CreateTable(
                "dbo.Warzywoes",
                c => new
                    {
                        WarzywoId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        CenaZaKg = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.WarzywoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zakups", "SprzedawcaId", "dbo.Sprzedawcas");
            DropForeignKey("dbo.Zakups", "ZakupJednostkowyId", "dbo.ZakupJednostkowies");
            DropForeignKey("dbo.ZakupJednostkowies", "WarzywoId", "dbo.Warzywoes");
            DropForeignKey("dbo.ZakupJednostkowies", "SprzedawcaId", "dbo.Sprzedawcas");
            DropIndex("dbo.ZakupJednostkowies", new[] { "SprzedawcaId" });
            DropIndex("dbo.ZakupJednostkowies", new[] { "WarzywoId" });
            DropIndex("dbo.Zakups", new[] { "ZakupJednostkowyId" });
            DropIndex("dbo.Zakups", new[] { "SprzedawcaId" });
            DropTable("dbo.Warzywoes");
            DropTable("dbo.ZakupJednostkowies");
            DropTable("dbo.Zakups");
            DropTable("dbo.Sprzedawcas");
        }
    }
}
