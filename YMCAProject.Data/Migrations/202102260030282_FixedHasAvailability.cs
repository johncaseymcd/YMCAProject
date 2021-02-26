namespace YMCAProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedHasAvailability : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "HasAvailability", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "HasAvailability");
        }
    }
}
