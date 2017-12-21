namespace SmartHealth.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class patient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "smart.Patient",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        UserAndRoleId = c.Int(nullable: false),
                        Age = c.String(),
                        Height = c.String(),
                        Weight = c.String(),
                        BloodPressure = c.String(),
                        BloodGroup = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("smart.UserAndRole", t => t.UserAndRoleId, cascadeDelete: true)
                .Index(t => t.UserAndRoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("smart.Patient", "UserAndRoleId", "smart.UserAndRole");
            DropIndex("smart.Patient", new[] { "UserAndRoleId" });
            DropTable("smart.Patient");
        }
    }
}
