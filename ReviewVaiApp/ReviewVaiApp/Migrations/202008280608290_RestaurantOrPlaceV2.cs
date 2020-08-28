namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantOrPlaceV2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "RestaurantOrPalce_Id", "dbo.RestaurantOrPalces");
            DropIndex("dbo.Posts", new[] { "RestaurantOrPalce_Id" });
            DropPrimaryKey("dbo.RestaurantOrPalces");
            AlterColumn("dbo.Posts", "RestaurantOrPalce_Id", c => c.Long());
            AlterColumn("dbo.RestaurantOrPalces", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.RestaurantOrPalces", "Id");
            CreateIndex("dbo.Posts", "RestaurantOrPalce_Id");
            AddForeignKey("dbo.Posts", "RestaurantOrPalce_Id", "dbo.RestaurantOrPalces", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "RestaurantOrPalce_Id", "dbo.RestaurantOrPalces");
            DropIndex("dbo.Posts", new[] { "RestaurantOrPalce_Id" });
            DropPrimaryKey("dbo.RestaurantOrPalces");
            AlterColumn("dbo.RestaurantOrPalces", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Posts", "RestaurantOrPalce_Id", c => c.Int());
            AddPrimaryKey("dbo.RestaurantOrPalces", "Id");
            CreateIndex("dbo.Posts", "RestaurantOrPalce_Id");
            AddForeignKey("dbo.Posts", "RestaurantOrPalce_Id", "dbo.RestaurantOrPalces", "Id");
        }
    }
}
