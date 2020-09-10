namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentReactionv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentReaction",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PostCommentId = c.Long(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        IsLiked = c.Int(nullable: false),
                        IsHelpfull = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.PostComment", t => t.PostCommentId, cascadeDelete: true)
                .Index(t => t.PostCommentId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentReaction", "PostCommentId", "dbo.PostComment");
            DropForeignKey("dbo.CommentReaction", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.CommentReaction", new[] { "ApplicationUserId" });
            DropIndex("dbo.CommentReaction", new[] { "PostCommentId" });
            DropTable("dbo.CommentReaction");
        }
    }
}
