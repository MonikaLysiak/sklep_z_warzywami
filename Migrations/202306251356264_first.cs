namespace SklepZWarzywami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
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
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.ZakupId)
                .ForeignKey("dbo.Sprzedawcas", t => t.SprzedawcaId, cascadeDelete: true)
                .Index(t => t.SprzedawcaId);
            
            CreateTable(
                "dbo.ZakupJednostkowies",
                c => new
                    {
                        ZakupJednostkowyId = c.Int(nullable: false, identity: true),
                        Waga = c.String(),
                        ZakupId = c.Int(nullable: false),
                        WarzywoId = c.Int(nullable: false),
                        Cena = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ZakupJednostkowyId)
                .ForeignKey("dbo.Warzywoes", t => t.WarzywoId, cascadeDelete: true)
                .ForeignKey("dbo.Zakups", t => t.ZakupId, cascadeDelete: true)
                .Index(t => t.ZakupId)
                .Index(t => t.WarzywoId);
            
            CreateTable(
                "dbo.Warzywoes",
                c => new
                    {
                        WarzywoId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        CenaZaKg = c.String(),
                        IloscNaStanie = c.String(),
                    })
                .PrimaryKey(t => t.WarzywoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZakupJednostkowies", "ZakupId", "dbo.Zakups");
            DropForeignKey("dbo.ZakupJednostkowies", "WarzywoId", "dbo.Warzywoes");
            DropForeignKey("dbo.Zakups", "SprzedawcaId", "dbo.Sprzedawcas");
            DropIndex("dbo.ZakupJednostkowies", new[] { "WarzywoId" });
            DropIndex("dbo.ZakupJednostkowies", new[] { "ZakupId" });
            DropIndex("dbo.Zakups", new[] { "SprzedawcaId" });
            DropTable("dbo.Warzywoes");
            DropTable("dbo.ZakupJednostkowies");
            DropTable("dbo.Zakups");
            DropTable("dbo.Sprzedawcas");
        }
    }
}
