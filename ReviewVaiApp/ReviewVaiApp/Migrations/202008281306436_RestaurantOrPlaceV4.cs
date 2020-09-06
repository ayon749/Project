namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantOrPlaceV4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RestaurantOrPalces", "RestOrPlace", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RestaurantOrPalces", "RestOrPlace", c => c.Byte(nullable: false));
        }
    }
}
