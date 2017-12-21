namespace SmartHealth.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "smart.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "smart.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        EmailId = c.String(),
                        Password = c.String(maxLength: 100),
                        ConfirmPassword = c.String(),
                        isauthenticated = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "smart.UserAndRole",
                c => new
                    {
                        UserAndRoleId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserAndRoleId)
                .ForeignKey("smart.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("smart.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("smart.UserAndRole", "UserId", "smart.User");
            DropForeignKey("smart.UserAndRole", "RoleId", "smart.Role");
            DropIndex("smart.UserAndRole", new[] { "RoleId" });
            DropIndex("smart.UserAndRole", new[] { "UserId" });
            DropTable("smart.UserAndRole");
            DropTable("smart.User");
            DropTable("smart.Role");
        }
    }
}
