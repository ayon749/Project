namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostTagsV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagPost",
                c => new
                    {
                        Tag_Id = c.Long(nullable: false),
                        Post_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Post_Id })
                .ForeignKey("dbo.Tag", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Post", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagPost", "Post_Id", "dbo.Post");
            DropForeignKey("dbo.TagPost", "Tag_Id", "dbo.Tag");
            DropIndex("dbo.TagPost", new[] { "Post_Id" });
            DropIndex("dbo.TagPost", new[] { "Tag_Id" });
            DropTable("dbo.TagPost");
        }
    }
}
