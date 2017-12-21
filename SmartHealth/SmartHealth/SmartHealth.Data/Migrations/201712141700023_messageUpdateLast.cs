namespace SmartHealth.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messageUpdateLast : DbMigration
    {
        public override void Up()
        {
            AddColumn("smart.Message", "CurrentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("smart.Message", "CurrentId");
        }
    }
}
