namespace ReviewVaiApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StarsV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Food = c.Double(nullable: false),
                        Environment = c.Double(nullable: false),
                        Service = c.Double(nullable: false),
                        Cleanliness = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stars");
        }
    }
}
