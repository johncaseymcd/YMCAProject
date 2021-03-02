namespace YMCAProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedIsCurrentlyRunning : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "IsCurrentlyRunning", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "IsCurrentlyRunning");
        }
    }
}
