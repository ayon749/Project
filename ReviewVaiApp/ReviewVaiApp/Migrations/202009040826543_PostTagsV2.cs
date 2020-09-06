namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostTagsV2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TagPost", newName: "TagPosts");
            RenameColumn(table: "dbo.TagPosts", name: "Tag_Id", newName: "TagId");
            RenameColumn(table: "dbo.TagPosts", name: "Post_Id", newName: "PostId");
            RenameIndex(table: "dbo.TagPosts", name: "IX_Post_Id", newName: "IX_PostId");
            RenameIndex(table: "dbo.TagPosts", name: "IX_Tag_Id", newName: "IX_TagId");
            DropPrimaryKey("dbo.TagPosts");
            AddPrimaryKey("dbo.TagPosts", new[] { "PostId", "TagId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TagPosts");
            AddPrimaryKey("dbo.TagPosts", new[] { "Tag_Id", "Post_Id" });
            RenameIndex(table: "dbo.TagPosts", name: "IX_TagId", newName: "IX_Tag_Id");
            RenameIndex(table: "dbo.TagPosts", name: "IX_PostId", newName: "IX_Post_Id");
            RenameColumn(table: "dbo.TagPosts", name: "PostId", newName: "Post_Id");
            RenameColumn(table: "dbo.TagPosts", name: "TagId", newName: "Tag_Id");
            RenameTable(name: "dbo.TagPosts", newName: "TagPost");
        }
    }
}
