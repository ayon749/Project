namespace ReviewApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUsersV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "GenderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "GenderId");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
