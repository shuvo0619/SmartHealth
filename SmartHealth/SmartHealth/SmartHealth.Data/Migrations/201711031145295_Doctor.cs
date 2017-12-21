namespace SmartHealth.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Doctor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "smart.Doctor",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        UserAndRoleId = c.Int(nullable: false),
                        HospitalId = c.Int(nullable: false),
                        Designation = c.String(),
                        Speciality = c.String(),
                        UniversityName = c.String(),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("smart.Hospital", t => t.HospitalId, cascadeDelete: true)
                .ForeignKey("smart.UserAndRole", t => t.UserAndRoleId, cascadeDelete: true)
                .Index(t => t.UserAndRoleId)
                .Index(t => t.HospitalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("smart.Doctor", "UserAndRoleId", "smart.UserAndRole");
            DropForeignKey("smart.Doctor", "HospitalId", "smart.Hospital");
            DropIndex("smart.Doctor", new[] { "HospitalId" });
            DropIndex("smart.Doctor", new[] { "UserAndRoleId" });
            DropTable("smart.Doctor");
        }
    }
}
