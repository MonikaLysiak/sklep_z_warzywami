namespace SklepZWarzywami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmianyZosi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Warzywoes", "CenaZaKg", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Warzywoes", "CenaZaKg", c => c.Double(nullable: false));
        }
    }
}
