namespace ReviewApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUsersV3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String());
        }
    }
}
