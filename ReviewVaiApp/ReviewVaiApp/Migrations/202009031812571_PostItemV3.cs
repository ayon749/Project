namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostItemV3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostItems", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.PostItems", "Item_Id", "dbo.Items");
            DropIndex("dbo.PostItems", new[] { "Post_Id" });
            DropIndex("dbo.PostItems", new[] { "Item_Id" });
            AddColumn("dbo.Items", "Post_Id", c => c.Long());
            CreateIndex("dbo.Items", "Post_Id");
            AddForeignKey("dbo.Items", "Post_Id", "dbo.Posts", "Id");
            DropTable("dbo.PostItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PostItems",
                c => new
                    {
                        Post_Id = c.Long(nullable: false),
                        Item_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_Id, t.Item_Id });
            
            DropForeignKey("dbo.Items", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Items", new[] { "Post_Id" });
            DropColumn("dbo.Items", "Post_Id");
            CreateIndex("dbo.PostItems", "Item_Id");
            CreateIndex("dbo.PostItems", "Post_Id");
            AddForeignKey("dbo.PostItems", "Item_Id", "dbo.Items", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PostItems", "Post_Id", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
