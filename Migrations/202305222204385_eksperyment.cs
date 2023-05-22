namespace SklepZWarzywami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eksperyment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Warzywoes", "IloscNaStanie", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Warzywoes", "IloscNaStanie", c => c.Double(nullable: false));
        }
    }
}
