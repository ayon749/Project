namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantOrPlaceV5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantOrPalces", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RestaurantOrPalces", "Location");
        }
    }
}
