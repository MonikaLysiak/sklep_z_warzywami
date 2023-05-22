namespace SklepZWarzywami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingWagaAndIloscNaStanieToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ZakupJednostkowies", "Waga", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ZakupJednostkowies", "Waga", c => c.Double(nullable: false));
        }
    }
}
