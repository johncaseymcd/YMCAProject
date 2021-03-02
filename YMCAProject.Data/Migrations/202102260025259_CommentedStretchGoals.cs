namespace YMCAProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentedStretchGoals : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "InstructorID", "dbo.Instructors");
            DropForeignKey("dbo.Courses", "LocationID", "dbo.Locations");
            DropIndex("dbo.Courses", new[] { "LocationID" });
            DropIndex("dbo.Courses", new[] { "InstructorID" });
            DropColumn("dbo.Courses", "LocationID");
            DropColumn("dbo.Courses", "InstructorID");
            DropTable("dbo.Instructors");
            DropTable("dbo.Locations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        InstructorID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.InstructorID);
            
            AddColumn("dbo.Courses", "InstructorID", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "LocationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "InstructorID");
            CreateIndex("dbo.Courses", "LocationID");
            AddForeignKey("dbo.Courses", "LocationID", "dbo.Locations", "LocationID", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "InstructorID", "dbo.Instructors", "InstructorID", cascadeDelete: true);
        }
    }
}
