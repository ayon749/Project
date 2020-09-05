namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoV2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Photos", "TimeStamp", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Photos", "TimeStamp", c => c.DateTime(nullable: false));
        }
    }
}
