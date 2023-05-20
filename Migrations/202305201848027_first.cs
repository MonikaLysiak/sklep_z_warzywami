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
                "dbo.Warzywoes",
                c => new
                    {
                        WarzywoId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        CenaZaKg = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.WarzywoId);
            
            CreateTable(
                "dbo.ZakupJednostkowies",
                c => new
                    {
                        ZakupJednostkowyId = c.Int(nullable: false, identity: true),
                        Waga = c.Double(nullable: false),
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
                "dbo.Zakups",
                c => new
                    {
                        ZakupId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ZakupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZakupJednostkowies", "ZakupId", "dbo.Zakups");
            DropForeignKey("dbo.ZakupJednostkowies", "WarzywoId", "dbo.Warzywoes");
            DropIndex("dbo.ZakupJednostkowies", new[] { "WarzywoId" });
            DropIndex("dbo.ZakupJednostkowies", new[] { "ZakupId" });
            DropTable("dbo.Zakups");
            DropTable("dbo.ZakupJednostkowies");
            DropTable("dbo.Warzywoes");
            DropTable("dbo.Sprzedawcas");
        }
    }
}
