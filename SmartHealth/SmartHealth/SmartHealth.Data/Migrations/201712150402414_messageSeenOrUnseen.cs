namespace SmartHealth.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messageSeenOrUnseen : DbMigration
    {
        public override void Up()
        {
            AddColumn("smart.Message", "SeenOrUnseen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("smart.Message", "SeenOrUnseen");
        }
    }
}
