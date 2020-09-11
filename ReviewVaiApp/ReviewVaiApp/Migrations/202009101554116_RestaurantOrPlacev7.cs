namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantOrPlacev7 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RestaurantOrPalce", newName: "RestaurantOrPlace");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.RestaurantOrPlace", newName: "RestaurantOrPalce");
        }
    }
}
