namespace SmartHealth.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class connections : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "smart.Connection",
                c => new
                    {
                        ConnectionID = c.String(nullable: false, maxLength: 128),
                        UserAgent = c.String(),
                        Connected = c.Boolean(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ConnectionID)
                .ForeignKey("smart.User", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("smart.Connection", "User_UserId", "smart.User");
            DropIndex("smart.Connection", new[] { "User_UserId" });
            DropTable("smart.Connection");
        }
    }
}
