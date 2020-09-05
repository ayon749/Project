namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagV3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "PostId", "dbo.Posts");
            DropIndex("dbo.Tags", new[] { "PostId" });
            RenameColumn(table: "dbo.Tags", name: "PostId", newName: "Post_Id");
            AlterColumn("dbo.Tags", "Post_Id", c => c.Long());
            CreateIndex("dbo.Tags", "Post_Id");
            AddForeignKey("dbo.Tags", "Post_Id", "dbo.Posts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Tags", new[] { "Post_Id" });
            AlterColumn("dbo.Tags", "Post_Id", c => c.Long(nullable: false));
            RenameColumn(table: "dbo.Tags", name: "Post_Id", newName: "PostId");
            CreateIndex("dbo.Tags", "PostId");
            AddForeignKey("dbo.Tags", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
