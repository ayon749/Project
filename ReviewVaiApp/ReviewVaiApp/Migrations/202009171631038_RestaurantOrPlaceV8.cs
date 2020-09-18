namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantOrPlaceV8 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RestaurantOrPlace", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.RestaurantOrPlace", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.RestaurantOrPlace", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.RestaurantOrPlace", name: "ApplicationUserId", newName: "ApplicationUser_Id");
        }
    }
}
