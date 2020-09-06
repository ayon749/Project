namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostCommentV2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PostComment", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostComment", "ParentId", c => c.Long(nullable: false));
        }
    }
}
