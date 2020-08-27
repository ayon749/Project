namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostV2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "Item");
            DropColumn("dbo.Posts", "Flag");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Flag", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Item", c => c.Int(nullable: false));
        }
    }
}
