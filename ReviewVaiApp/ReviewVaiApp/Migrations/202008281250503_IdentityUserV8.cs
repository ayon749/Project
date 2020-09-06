namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityUserV8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "BadgeId", "dbo.Badges");
            DropForeignKey("dbo.AspNetUsers", "ProfileTitleId", "dbo.ProfileTitles");
            DropIndex("dbo.AspNetUsers", new[] { "ProfileTitleId" });
            DropIndex("dbo.AspNetUsers", new[] { "BadgeId" });
            AlterColumn("dbo.AspNetUsers", "ProfileTitleId", c => c.Long());
            AlterColumn("dbo.AspNetUsers", "BadgeId", c => c.Long());
            CreateIndex("dbo.AspNetUsers", "ProfileTitleId");
            CreateIndex("dbo.AspNetUsers", "BadgeId");
            AddForeignKey("dbo.AspNetUsers", "BadgeId", "dbo.Badges", "Id");
            AddForeignKey("dbo.AspNetUsers", "ProfileTitleId", "dbo.ProfileTitles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ProfileTitleId", "dbo.ProfileTitles");
            DropForeignKey("dbo.AspNetUsers", "BadgeId", "dbo.Badges");
            DropIndex("dbo.AspNetUsers", new[] { "BadgeId" });
            DropIndex("dbo.AspNetUsers", new[] { "ProfileTitleId" });
            AlterColumn("dbo.AspNetUsers", "BadgeId", c => c.Long(nullable: false));
            AlterColumn("dbo.AspNetUsers", "ProfileTitleId", c => c.Long(nullable: false));
            CreateIndex("dbo.AspNetUsers", "BadgeId");
            CreateIndex("dbo.AspNetUsers", "ProfileTitleId");
            AddForeignKey("dbo.AspNetUsers", "ProfileTitleId", "dbo.ProfileTitles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "BadgeId", "dbo.Badges", "Id", cascadeDelete: true);
        }
    }
}
