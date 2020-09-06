namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReactionV2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Reactions", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Reactions", "ApplicationUserId");
            RenameColumn(table: "dbo.Reactions", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Reactions", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reactions", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Reactions", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Reactions", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Reactions", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Reactions", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reactions", "ApplicationUser_Id");
        }
    }
}
