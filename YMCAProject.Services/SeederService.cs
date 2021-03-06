using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMCAProject.Models;
using YMCAProject.Data;
using YMCAProject.WebAPI.Data;

namespace YMCAProject.Services
{
    public class SeederService
    {
        public bool SeedDatabase()
        {
            var ctx = new ApplicationDbContext();

            // Create Locations
            // ----------------
            var firstLocation = new Location
            {
                LocationID = 1,
                LocationName = "Indy YMCA",
                LocationStreetNumber = 3146,
                LocationStreetName = "West Main St",
                LocationCity = "Indianapolis",
                LocationState = "IN",
                LocationZipCode = 46240,
                LocationPhoneNumber = "317-555-9473",
                LocationEmail = "info@indyymca.com"
            };
            ctx.Locations.Add(firstLocation);

            var secondLocation = new Location
            {
                LocationID = 2,
                LocationName = "Carmel YMCA",
                LocationStreetNumber = 12408,
                LocationStreetName = "N Rangeline Rd",
                LocationCity = "Carmel",
                LocationState = "IN",
                LocationZipCode = 46032,
                LocationPhoneNumber = "317-555-6324",
                LocationEmail = "info@carmelymca.com"
            };
            ctx.Locations.Add(secondLocation);

            var thirdLocation = new Location
            {
                LocationID = 3,
                LocationName = "Avon YMCA",
                LocationStreetNumber = 7614,
                LocationStreetName = "West Rockville Rd",
                LocationCity = "Avon",
                LocationState = "IN",
                LocationZipCode = 46123,
                LocationPhoneNumber = "317-555-0597",
                LocationEmail = "info@avonymca.com"
            };
            ctx.Locations.Add(thirdLocation);

            // Create Courses
            // --------------
            var firstCourse = new Course
            {
                CourseID = 1,
                CourseName = "Pilates",
                CourseDescription = "Guaranteed to be harder than you think it is.",
                CourseCost = 250.00m,
                MaxCourseSize = 25,
                LocationID = 2,
                InstructorID = 1,
                CourseStartDate = new DateTime(2021, 03, 01),
                CourseEndDate = new DateTime(2021, 06, 01)
            };
            ctx.Courses.Add(firstCourse);

            var secondCourse = new Course
            {
                CourseID = 2,
                CourseName = "Yoga",
                CourseDescription = "Slightly easier than pilates. Only slightly.",
                CourseCost = 150.00m,
                MaxCourseSize = 40,
                LocationID = 1,
                InstructorID = 2,
                CourseStartDate = new DateTime(2021, 01, 01),
                CourseEndDate = new DateTime(2021, 04, 01)
            };
            ctx.Courses.Add(secondCourse);

            var thirdCourse = new Course
            {
                CourseID = 3,
                CourseName = "Weightlifting",
                CourseDescription = "Why yes, I do lift, thank you for noticing.",
                CourseCost = 100.00m,
                MaxCourseSize = 50,
                LocationID = 3,
                InstructorID = 3,
                CourseStartDate = new DateTime(2021, 07, 01),
                CourseEndDate = new DateTime(2021, 10, 01)
            };
            ctx.Courses.Add(thirdCourse);

            // Create Invoices
            // ---------------
            var firstInvoice = new Invoice
            {
                InvoiceID = 1,
                MemberID = 1,
                InvoiceDescription = "Monthly Billing Cycle for February 2021",
                MonthlyFee = 29.99m,
                InvoiceDueDate = new DateTime(2021, 03, 15),
                CreatedUtc = DateTimeOffset.Now
            };
            ctx.Invoices.Add(firstInvoice);

            var secondInvoice = new Invoice
            {
                InvoiceID = 2,
                MemberID = 2,
                InvoiceDescription = "Monthly Billing Cycle for February 2021",
                MonthlyFee = 24.99m,
                InvoiceDueDate = new DateTime(2021, 03, 15),
                CreatedUtc = DateTimeOffset.Now
            };
            ctx.Invoices.Add(secondInvoice);

            var thirdInvoice = new Invoice
            {
                InvoiceID = 3,
                MemberID = 3,
                InvoiceDescription = "Monthly Billing Cycle for February 2021",
                MonthlyFee = 29.99m,
                InvoiceDueDate = new DateTime(2021, 03, 15),
                CreatedUtc = DateTimeOffset.Now
            };
            ctx.Invoices.Add(thirdInvoice);

            // Create Members
            // --------------
            var firstMember = new Member
            {
                MemberID = 1,
                DateJoined = new DateTime(2021, 1, 1),
                Name = "Casey McDonough",
                Email = "cmcdonough@mail.com",
                Address = "456 N Elm St, Indianapolis, IN 46202",
                LocationID = 1,
                PhoneNumber = "317-555-1649",
                CreditCardNumber = 4444888866662222,
                ExpirationDate = "11/24",
                SecurityCode = 547
            };
            ctx.Members.Add(firstMember);

            var secondMember = new Member
            {
                MemberID = 2,
                DateJoined = DateTime.Now,
                Name = "Steve Shotts",
                Email = "sshotts@mail.com",
                Address = "789 E Oak St, Indianapolis, IN 46250",
                LocationID = 2,
                PhoneNumber = "317-555-9151",
                CreditCardNumber = 4444333377771111,
                ExpirationDate = "10/22",
                SecurityCode = 630
            };
            ctx.Members.Add(secondMember);

            var thirdMember = new Member
            {
                MemberID = 3,
                DateJoined = new DateTime(2010, 07, 15),
                Name = "Andrew Steward",
                Email = "asteward@mail.com",
                Address = "321 W 52nd St, Indianapolis, IN 46220",
                LocationID = 3,
                PhoneNumber = "317-555-8520",
                CreditCardNumber = 4444111100006666,
                ExpirationDate = "07/23",
                SecurityCode = 218
            };
            ctx.Members.Add(thirdMember);

            // Create Instructors
            // ------------------
            var firstInstructor = new Instructor
            {
                InstructorID = 1,
                InstructorName = "Amanda Knight",
                LocationID = 2
            };
            ctx.Instructors.Add(firstInstructor);

            var secondInstructor = new Instructor
            {
                InstructorID = 2,
                InstructorName = "Sabra Snider",
                LocationID = 1
            };
            ctx.Instructors.Add(secondInstructor);

            var thirdInstructor = new Instructor
            {
                InstructorID = 3,
                InstructorName = "Severa Cox",
                LocationID = 3
            };
            ctx.Instructors.Add(thirdInstructor);

            // Perform relational assignments and calculations
            // -----------------------------------------------
            firstMember.CoursesTaken.Add(secondCourse);
            secondMember.CoursesTaken.Add(firstCourse);
            thirdMember.CoursesTaken.Add(thirdCourse);

            firstCourse.ListOfMembers.Add(secondMember);
            secondCourse.ListOfMembers.Add(firstMember);
            thirdCourse.ListOfMembers.Add(thirdMember);

            firstInvoice.CoursesTaken = firstMember.CoursesTaken;
            secondInvoice.CoursesTaken = secondMember.CoursesTaken;
            thirdInvoice.CoursesTaken = thirdMember.CoursesTaken;

            firstMember.Invoices.Add(firstInvoice);
            secondMember.Invoices.Add(secondInvoice);
            thirdMember.Invoices.Add(thirdInvoice);

            firstInstructor.CoursesTaught.Add(firstCourse);
            secondInstructor.CoursesTaught.Add(secondCourse);
            thirdInstructor.CoursesTaught.Add(thirdCourse);

            firstLocation.ListOfMembers.Add(firstMember);
            secondLocation.ListOfMembers.Add(secondMember);
            thirdLocation.ListOfMembers.Add(thirdMember);

            return ctx.SaveChanges() > 0;
        }

        // Clear existing entries in database
        public bool ClearDatabase()
        {
            using (var ctx = new ApplicationDbContext())
            {
                foreach(var course in ctx.Courses)
                {
                    ctx.Courses.Remove(course);
                }

                foreach(var instructor in ctx.Instructors)
                {
                    ctx.Instructors.Remove(instructor);
                }

                foreach(var invoice in ctx.Invoices)
                {
                    ctx.Invoices.Remove(invoice);
                }

                foreach(var location in ctx.Locations)
                {
                    ctx.Locations.Remove(location);
                }

                foreach(var member in ctx.Members)
                {
                    ctx.Members.Remove(member);
                }

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
