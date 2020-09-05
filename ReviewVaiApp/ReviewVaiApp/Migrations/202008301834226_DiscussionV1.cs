namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscussionV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discussions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Question = c.String(),
                        TimeStamp = c.DateTime(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.DiscussionComments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DiscussionCommentId = c.Long(nullable: false),
                        Text = c.String(),
                        ParentId = c.Long(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Discussion_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.DiscussionComments", t => t.DiscussionCommentId)
                .ForeignKey("dbo.Discussions", t => t.Discussion_Id)
                .Index(t => t.DiscussionCommentId)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Discussion_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiscussionComments", "Discussion_Id", "dbo.Discussions");
            DropForeignKey("dbo.DiscussionComments", "DiscussionCommentId", "dbo.DiscussionComments");
            DropForeignKey("dbo.DiscussionComments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Discussions", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.DiscussionComments", new[] { "Discussion_Id" });
            DropIndex("dbo.DiscussionComments", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.DiscussionComments", new[] { "DiscussionCommentId" });
            DropIndex("dbo.Discussions", new[] { "ApplicationUser_Id" });
            DropTable("dbo.DiscussionComments");
            DropTable("dbo.Discussions");
        }
    }
}
