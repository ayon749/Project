namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostCommentV1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Tags", new[] { "Post_Id" });
            CreateTable(
                "dbo.PostComments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PostId = c.Long(nullable: false),
                        Text = c.String(),
                        ParentId = c.Long(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.ApplicationUser_Id);
            
            DropColumn("dbo.Tags", "Post_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Post_Id", c => c.Long());
            DropForeignKey("dbo.PostComments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.PostComments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PostComments", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.PostComments", new[] { "PostId" });
            DropTable("dbo.PostComments");
            CreateIndex("dbo.Tags", "Post_Id");
            AddForeignKey("dbo.Tags", "Post_Id", "dbo.Posts", "Id");
        }
    }
}
