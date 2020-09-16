namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostV9 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Post", name: "RestaurantOrPalce_Id", newName: "RestaurantOrPalceId");
            RenameIndex(table: "dbo.Post", name: "IX_RestaurantOrPalce_Id", newName: "IX_RestaurantOrPalceId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Post", name: "IX_RestaurantOrPalceId", newName: "IX_RestaurantOrPalce_Id");
            RenameColumn(table: "dbo.Post", name: "RestaurantOrPalceId", newName: "RestaurantOrPalce_Id");
        }
    }
}
