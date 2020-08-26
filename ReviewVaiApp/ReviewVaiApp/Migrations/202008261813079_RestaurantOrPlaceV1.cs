﻿namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestaurantOrPlaceV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantOrPalces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalRecommendation = c.Int(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                        TotalReviews = c.Int(nullable: false),
                        RestOrPlace = c.Byte(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantOrPalces", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RestaurantOrPalces", new[] { "ApplicationUser_Id" });
            DropTable("dbo.RestaurantOrPalces");
        }
    }
}
