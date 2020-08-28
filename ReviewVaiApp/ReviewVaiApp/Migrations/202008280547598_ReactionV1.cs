namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReactionV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reactions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PostId = c.Long(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                        IsLiked = c.Int(nullable: false),
                        IsHelpfull = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reactions", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Reactions", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reactions", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Reactions", new[] { "PostId" });
            DropTable("dbo.Reactions");
        }
    }
}
