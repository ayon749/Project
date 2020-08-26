namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityUserV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Photo", c => c.String());
            AddColumn("dbo.AspNetUsers", "location", c => c.String());
            AddColumn("dbo.AspNetUsers", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Badge", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "ProfileTitle", c => c.String());
            AddColumn("dbo.AspNetUsers", "Contact", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "ProfileType", c => c.String());
            AddColumn("dbo.AspNetUsers", "IsBanned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsBanned");
            DropColumn("dbo.AspNetUsers", "ProfileType");
            DropColumn("dbo.AspNetUsers", "Contact");
            DropColumn("dbo.AspNetUsers", "ProfileTitle");
            DropColumn("dbo.AspNetUsers", "Badge");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "CreatedAt");
            DropColumn("dbo.AspNetUsers", "location");
            DropColumn("dbo.AspNetUsers", "Photo");
        }
    }
}
