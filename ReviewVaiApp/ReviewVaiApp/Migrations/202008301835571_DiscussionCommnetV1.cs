namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscussionCommnetV1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DiscussionComments", "DiscussionCommentId", "dbo.DiscussionComments");
            DropForeignKey("dbo.DiscussionComments", "Discussion_Id", "dbo.Discussions");
            DropIndex("dbo.DiscussionComments", new[] { "DiscussionCommentId" });
            DropIndex("dbo.DiscussionComments", new[] { "Discussion_Id" });
            RenameColumn(table: "dbo.DiscussionComments", name: "Discussion_Id", newName: "DiscussionId");
            AlterColumn("dbo.DiscussionComments", "DiscussionId", c => c.Long(nullable: false));
            CreateIndex("dbo.DiscussionComments", "DiscussionId");
            AddForeignKey("dbo.DiscussionComments", "DiscussionId", "dbo.Discussions", "Id", cascadeDelete: true);
            DropColumn("dbo.DiscussionComments", "DiscussionCommentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DiscussionComments", "DiscussionCommentId", c => c.Long(nullable: false));
            DropForeignKey("dbo.DiscussionComments", "DiscussionId", "dbo.Discussions");
            DropIndex("dbo.DiscussionComments", new[] { "DiscussionId" });
            AlterColumn("dbo.DiscussionComments", "DiscussionId", c => c.Long());
            RenameColumn(table: "dbo.DiscussionComments", name: "DiscussionId", newName: "Discussion_Id");
            CreateIndex("dbo.DiscussionComments", "Discussion_Id");
            CreateIndex("dbo.DiscussionComments", "DiscussionCommentId");
            AddForeignKey("dbo.DiscussionComments", "Discussion_Id", "dbo.Discussions", "Id");
            AddForeignKey("dbo.DiscussionComments", "DiscussionCommentId", "dbo.DiscussionComments", "Id");
        }
    }
}
