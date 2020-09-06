namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantOrPlaceV6 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RestaurantOrPalces", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.RestaurantOrPalces", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.RestaurantOrPalces", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
            RenameColumn(table: "dbo.RestaurantOrPalces", name: "ApplicationUser_Id", newName: "ApplicationUserId");
        }
    }
}
