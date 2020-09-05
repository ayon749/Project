namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostItemV4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Items", new[] { "Post_Id" });
            CreateTable(
                "dbo.PostItems",
                c => new
                    {
                        Post_Id = c.Long(nullable: false),
                        Item_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_Id, t.Item_Id })
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.Post_Id)
                .Index(t => t.Item_Id);
            
            DropColumn("dbo.Items", "Post_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Post_Id", c => c.Long());
            DropForeignKey("dbo.PostItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.PostItems", "Post_Id", "dbo.Posts");
            DropIndex("dbo.PostItems", new[] { "Item_Id" });
            DropIndex("dbo.PostItems", new[] { "Post_Id" });
            DropTable("dbo.PostItems");
            CreateIndex("dbo.Items", "Post_Id");
            AddForeignKey("dbo.Items", "Post_Id", "dbo.Posts", "Id");
        }
    }
}
