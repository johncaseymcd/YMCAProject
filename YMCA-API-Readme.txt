1.      About the Project

The YMCA Member database looks to incorporate a standard n-tier architecture with a Web API to solve a business problem. The business problem in question is how a generic fitness club, such as a YMCA, could track members, invoices, courses, locations, and instructors dynamically and make real time changes, updates, and reports that assist in the core business operations.

2.      Getting Started

The Web API utilizes .Net 4.8, Entity Framework 6.0, and Owin 2.3.3 and all dependents of those projects. A full list of dependencies can be found in the Web.Config file of the WebAPI Project in Github.

3.      Usage and Endpoints

A local database must be created as the project is not hosted. Standard migrations can be employed to deploy the database and test functionality with an application such as Postman. Each Endpoint is categorized under the applicable data class.

Member
GET api/Member/all
Request for database to show all members
POST api/Member
Request to add a member to a database
GET api/member/{id}
Request to get a specific member by ID
PUT api/member/{id}
Request to update a member by ID
DELETE api/member/{id}
Request to delete a member by ID

Invoice
GET api/Invoice/all
Request to show all invoices
POST api/Invoice
Request to add an invoice to the database
GET api/Invoice/{id}
Request to get an invoice by ID
PUT api/Invoice/{id}
Request to update an existing invoice by ID
DELETE api/Invoice/{id}
Request to delete an invoice by ID


Course
POST api/Course
Request to add a course to the database
GET api/Course
Request to show all courses
GET api/Course/{id}
Request to show a specific course by ID
GET api/Course/open
Request to show only open courses
GET api/Course/Current
Request to show all current courses
POST api/Course/{courseID}billto/{invoiceID}
Request to add a course to an invoice
GET  api/Course/Instructor/{id}?instructorID={instructorID}
Request to show the instructor of a course
GET api/Course/Location/{id}?locationID={locationID}
Request to show courses by locations
PUT api/Course/{id}
Request to update a course by ID
DELETE api/Course/{id}
Request to delete a course by ID


4.      Roadmap

Please see the open issues portion of Github for any pending developing updates or known issues.

5.      Contributing

The project authors are Casey, Steve, and Andrew