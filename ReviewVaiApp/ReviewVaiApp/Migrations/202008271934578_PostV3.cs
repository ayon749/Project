namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostV3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Stars_Id", c => c.Int());
            CreateIndex("dbo.Posts", "Stars_Id");
            AddForeignKey("dbo.Posts", "Stars_Id", "dbo.Stars", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Stars_Id", "dbo.Stars");
            DropIndex("dbo.Posts", new[] { "Stars_Id" });
            DropColumn("dbo.Posts", "Stars_Id");
        }
    }
}
