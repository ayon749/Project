namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostV4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        TimeStamp = c.DateTime(),
                        PostId = c.Long(nullable: false),
                        FOodOrTravel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "PostId", "dbo.Posts");
            DropIndex("dbo.Tags", new[] { "PostId" });
            DropTable("dbo.Tags");
        }
    }
}
