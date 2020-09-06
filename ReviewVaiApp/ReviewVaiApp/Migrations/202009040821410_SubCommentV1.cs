namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubCommentV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubComment",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PostCommentId = c.Long(nullable: false),
                        Text = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.PostComment", t => t.PostCommentId, cascadeDelete: true)
                .Index(t => t.PostCommentId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubComment", "PostCommentId", "dbo.PostComment");
            DropForeignKey("dbo.SubComment", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.SubComment", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SubComment", new[] { "PostCommentId" });
            DropTable("dbo.SubComment");
        }
    }
}
