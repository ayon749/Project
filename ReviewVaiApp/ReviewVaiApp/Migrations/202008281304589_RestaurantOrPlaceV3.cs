namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantOrPlaceV3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.RestaurantOrPalces", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.RestaurantOrPalces", "ApplicationUserId");
            RenameColumn(table: "dbo.RestaurantOrPalces", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.RestaurantOrPalces", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.RestaurantOrPalces", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.RestaurantOrPalces", new[] { "ApplicationUserId" });
            AlterColumn("dbo.RestaurantOrPalces", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.RestaurantOrPalces", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.RestaurantOrPalces", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.RestaurantOrPalces", "ApplicationUser_Id");
        }
    }
}
