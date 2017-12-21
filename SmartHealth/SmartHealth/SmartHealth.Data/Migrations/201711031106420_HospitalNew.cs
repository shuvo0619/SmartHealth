namespace SmartHealth.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HospitalNew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "smart.Hospital",
                c => new
                    {
                        HospitalId = c.Int(nullable: false, identity: true),
                        HospitalName = c.String(),
                        Speciality = c.String(),
                        Description = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.HospitalId);
            
        }
        
        public override void Down()
        {
            DropTable("smart.Hospital");
        }
    }
}
