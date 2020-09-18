namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplyReactionV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReplyReaction",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SubCommentId = c.Long(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        IsLiked = c.Int(nullable: false),
                        IsHelpfull = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.SubComment", t => t.SubCommentId, cascadeDelete: true)
                .Index(t => t.SubCommentId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReplyReaction", "SubCommentId", "dbo.SubComment");
            DropForeignKey("dbo.ReplyReaction", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.ReplyReaction", new[] { "ApplicationUserId" });
            DropIndex("dbo.ReplyReaction", new[] { "SubCommentId" });
            DropTable("dbo.ReplyReaction");
        }
    }
}
