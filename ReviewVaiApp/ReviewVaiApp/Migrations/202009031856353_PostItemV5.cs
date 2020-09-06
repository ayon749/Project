namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostItemV5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Badges", newName: "Badge");
            RenameTable(name: "dbo.DiscussionComments", newName: "DiscussionComment");
            RenameTable(name: "dbo.ProfileTitles", newName: "ProfileTitle");
            RenameTable(name: "dbo.Discussions", newName: "Discussion");
            RenameTable(name: "dbo.Items", newName: "Item");
            RenameTable(name: "dbo.Posts", newName: "Post");
            RenameTable(name: "dbo.Photos", newName: "Photo");
            RenameTable(name: "dbo.Reactions", newName: "Reaction");
            RenameTable(name: "dbo.RestaurantOrPalces", newName: "RestaurantOrPalce");
            RenameTable(name: "dbo.PostComments", newName: "PostComment");
            RenameTable(name: "dbo.Tags", newName: "Tag");
            RenameColumn(table: "dbo.PostItems", name: "Post_Id", newName: "PostId");
            RenameColumn(table: "dbo.PostItems", name: "Item_Id", newName: "ItemId");
            RenameIndex(table: "dbo.PostItems", name: "IX_Post_Id", newName: "IX_PostId");
            RenameIndex(table: "dbo.PostItems", name: "IX_Item_Id", newName: "IX_ItemId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PostItems", name: "IX_ItemId", newName: "IX_Item_Id");
            RenameIndex(table: "dbo.PostItems", name: "IX_PostId", newName: "IX_Post_Id");
            RenameColumn(table: "dbo.PostItems", name: "ItemId", newName: "Item_Id");
            RenameColumn(table: "dbo.PostItems", name: "PostId", newName: "Post_Id");
            RenameTable(name: "dbo.Tag", newName: "Tags");
            RenameTable(name: "dbo.PostComment", newName: "PostComments");
            RenameTable(name: "dbo.RestaurantOrPalce", newName: "RestaurantOrPalces");
            RenameTable(name: "dbo.Reaction", newName: "Reactions");
            RenameTable(name: "dbo.Photo", newName: "Photos");
            RenameTable(name: "dbo.Post", newName: "Posts");
            RenameTable(name: "dbo.Item", newName: "Items");
            RenameTable(name: "dbo.Discussion", newName: "Discussions");
            RenameTable(name: "dbo.ProfileTitle", newName: "ProfileTitles");
            RenameTable(name: "dbo.DiscussionComment", newName: "DiscussionComments");
            RenameTable(name: "dbo.Badge", newName: "Badges");
        }
    }
}
