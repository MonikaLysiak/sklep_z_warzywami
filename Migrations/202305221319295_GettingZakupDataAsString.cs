namespace SklepZWarzywami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GettingZakupDataAsString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Zakups", "Data", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zakups", "Data", c => c.DateTime(nullable: false));
        }
    }
}
