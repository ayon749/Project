namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BadgeV2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Badges", "Point", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Badges", "Point", c => c.String());
        }
    }
}
