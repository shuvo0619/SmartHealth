namespace SmartHealth.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messageUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("smart.Message", "DoctorId", "smart.Doctor");
            DropIndex("smart.Message", new[] { "DoctorId" });
            AddColumn("smart.Message", "UserId", c => c.Int(nullable: false));
            CreateIndex("smart.Message", "UserId");
            AddForeignKey("smart.Message", "UserId", "smart.User", "UserId", cascadeDelete: true);
            DropColumn("smart.Message", "DoctorId");
        }
        
        public override void Down()
        {
            AddColumn("smart.Message", "DoctorId", c => c.Int(nullable: false));
            DropForeignKey("smart.Message", "UserId", "smart.User");
            DropIndex("smart.Message", new[] { "UserId" });
            DropColumn("smart.Message", "UserId");
            CreateIndex("smart.Message", "DoctorId");
            AddForeignKey("smart.Message", "DoctorId", "smart.Doctor", "DoctorId", cascadeDelete: true);
        }
    }
}
