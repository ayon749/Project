namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostTitle = c.String(),
                        IsOfferOrPlanned = c.Boolean(nullable: false),
                        IsRecommended = c.Boolean(nullable: false),
                        Item = c.Int(nullable: false),
                        RestaurantOrPalceId = c.Int(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                        Tags = c.String(),
                        TimePosted = c.DateTime(),
                        PostBody = c.String(),
                        Flag = c.Int(nullable: false),
                        FoodOrTravel = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.RestaurantOrPalces", t => t.RestaurantOrPalceId, cascadeDelete: true)
                .Index(t => t.RestaurantOrPalceId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "RestaurantOrPalceId", "dbo.RestaurantOrPalces");
            DropForeignKey("dbo.Posts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Posts", new[] { "RestaurantOrPalceId" });
            DropTable("dbo.Posts");
        }
    }
}
