namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotosV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PostId = c.Long(nullable: false),
                        Caption = c.String(),
                        Url = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "PostId", "dbo.Posts");
            DropIndex("dbo.Photos", new[] { "PostId" });
            DropTable("dbo.Photos");
        }
    }
}
