namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityUserV6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Badge");
            DropColumn("dbo.AspNetUsers", "ProfileTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ProfileTitle", c => c.String());
            AddColumn("dbo.AspNetUsers", "Badge", c => c.Int(nullable: false));
        }
    }
}
