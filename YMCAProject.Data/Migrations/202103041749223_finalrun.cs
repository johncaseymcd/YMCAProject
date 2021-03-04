namespace YMCAProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalrun : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        CourseDescription = c.String(nullable: false),
                        CourseCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxCourseSize = c.Int(nullable: false),
                        HasAvailability = c.Boolean(nullable: false),
                        LocationID = c.Int(nullable: false),
                        InstructorID = c.Int(nullable: false),
                        CourseStartDate = c.DateTime(nullable: false),
                        CourseEndDate = c.DateTime(nullable: false),
                        IsCurrentlyRunning = c.Boolean(nullable: false),
                        Invoice_InvoiceID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Instructors", t => t.InstructorID, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID)
                .Index(t => t.InstructorID)
                .Index(t => t.Invoice_InvoiceID);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        InstructorID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.InstructorID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        DateJoined = c.DateTime(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        CreditCardNumber = c.Long(nullable: false),
                        ExpirationDate = c.String(),
                        SecurityCode = c.Int(nullable: false),
                        Location_LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.MemberID)
                .ForeignKey("dbo.Locations", t => t.Location_LocationID)
                .Index(t => t.Location_LocationID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        MemberID = c.Int(nullable: false),
                        InvoiceDescription = c.String(nullable: false),
                        InvoiceDueDate = c.DateTimeOffset(nullable: false, precision: 7),
                        InvoiceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceIsPaid = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Members", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        LocationName = c.String(nullable: false),
                        LocationStreetNumber = c.Int(nullable: false),
                        LocationStreetName = c.String(nullable: false),
                        LocationCity = c.String(nullable: false),
                        LocationState = c.String(nullable: false),
                        LocationZipCode = c.Int(nullable: false),
                        LocationPhoneNumber = c.String(nullable: false),
                        LocationEmail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MemberCourses",
                c => new
                    {
                        Member_MemberID = c.Int(nullable: false),
                        Course_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_MemberID, t.Course_CourseID })
                .ForeignKey("dbo.Members", t => t.Member_MemberID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID, cascadeDelete: true)
                .Index(t => t.Member_MemberID)
                .Index(t => t.Course_CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Courses", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Members", "Location_LocationID", "dbo.Locations");
            DropForeignKey("dbo.Invoices", "MemberID", "dbo.Members");
            DropForeignKey("dbo.Courses", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.MemberCourses", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.MemberCourses", "Member_MemberID", "dbo.Members");
            DropForeignKey("dbo.Courses", "InstructorID", "dbo.Instructors");
            DropIndex("dbo.MemberCourses", new[] { "Course_CourseID" });
            DropIndex("dbo.MemberCourses", new[] { "Member_MemberID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Invoices", new[] { "MemberID" });
            DropIndex("dbo.Members", new[] { "Location_LocationID" });
            DropIndex("dbo.Courses", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.Courses", new[] { "InstructorID" });
            DropIndex("dbo.Courses", new[] { "LocationID" });
            DropTable("dbo.MemberCourses");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Locations");
            DropTable("dbo.Invoices");
            DropTable("dbo.Members");
            DropTable("dbo.Instructors");
            DropTable("dbo.Courses");
        }
    }
}
