namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityUserV7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ProfileTitleId", c => c.Long(nullable: false));
            AddColumn("dbo.AspNetUsers", "BadgeId", c => c.Long(nullable: false));
            CreateIndex("dbo.AspNetUsers", "ProfileTitleId");
            CreateIndex("dbo.AspNetUsers", "BadgeId");
            AddForeignKey("dbo.AspNetUsers", "BadgeId", "dbo.Badges", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "ProfileTitleId", "dbo.ProfileTitles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ProfileTitleId", "dbo.ProfileTitles");
            DropForeignKey("dbo.AspNetUsers", "BadgeId", "dbo.Badges");
            DropIndex("dbo.AspNetUsers", new[] { "BadgeId" });
            DropIndex("dbo.AspNetUsers", new[] { "ProfileTitleId" });
            DropColumn("dbo.AspNetUsers", "BadgeId");
            DropColumn("dbo.AspNetUsers", "ProfileTitleId");
        }
    }
}
