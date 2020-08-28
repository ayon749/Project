namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StarsV2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Stars_Id", "dbo.Stars");
            DropIndex("dbo.Posts", new[] { "Stars_Id" });
            DropPrimaryKey("dbo.Stars");
            AlterColumn("dbo.Posts", "Stars_Id", c => c.Long());
            AlterColumn("dbo.Stars", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Stars", "Id");
            CreateIndex("dbo.Posts", "Stars_Id");
            AddForeignKey("dbo.Posts", "Stars_Id", "dbo.Stars", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Stars_Id", "dbo.Stars");
            DropIndex("dbo.Posts", new[] { "Stars_Id" });
            DropPrimaryKey("dbo.Stars");
            AlterColumn("dbo.Stars", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Posts", "Stars_Id", c => c.Int());
            AddPrimaryKey("dbo.Stars", "Id");
            CreateIndex("dbo.Posts", "Stars_Id");
            AddForeignKey("dbo.Posts", "Stars_Id", "dbo.Stars", "Id");
        }
    }
}
