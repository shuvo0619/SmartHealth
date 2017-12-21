namespace SmartHealth.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class message : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "smart.Message",
                c => new
                    {
                        ConnectionId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MessageBody = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ConnectionId)
                .ForeignKey("smart.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("smart.Message", "UserId", "smart.User");
            DropIndex("smart.Message", new[] { "UserId" });
            DropTable("smart.Message");
        }
    }
}
