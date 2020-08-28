namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagV1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "RestaurantOrPalceId", "dbo.RestaurantOrPalces");
            DropIndex("dbo.Posts", new[] { "RestaurantOrPalceId" });
            RenameColumn(table: "dbo.Posts", name: "RestaurantOrPalceId", newName: "RestaurantOrPalce_Id");
            DropPrimaryKey("dbo.Posts");
            AlterColumn("dbo.Posts", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Posts", "RestaurantOrPalce_Id", c => c.Int());
            AddPrimaryKey("dbo.Posts", "Id");
            CreateIndex("dbo.Posts", "RestaurantOrPalce_Id");
            AddForeignKey("dbo.Posts", "RestaurantOrPalce_Id", "dbo.RestaurantOrPalces", "Id");
            DropColumn("dbo.Posts", "Tags");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Tags", c => c.String());
            DropForeignKey("dbo.Posts", "RestaurantOrPalce_Id", "dbo.RestaurantOrPalces");
            DropIndex("dbo.Posts", new[] { "RestaurantOrPalce_Id" });
            DropPrimaryKey("dbo.Posts");
            AlterColumn("dbo.Posts", "RestaurantOrPalce_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Posts", "Id");
            RenameColumn(table: "dbo.Posts", name: "RestaurantOrPalce_Id", newName: "RestaurantOrPalceId");
            CreateIndex("dbo.Posts", "RestaurantOrPalceId");
            AddForeignKey("dbo.Posts", "RestaurantOrPalceId", "dbo.RestaurantOrPalces", "Id", cascadeDelete: true);
        }
    }
}
