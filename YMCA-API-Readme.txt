1.      About the Project

The YMCA Member database looks to incorporate a standard n-tier architecture with a Web API to solve a business problem. The business problem in question is how a generic fitness club, such as a YMCA, could track members, invoices, courses, locations, and instructors dynamically and make real time changes, updates, and reports that assist in the core business operations.

The planning document for this project can be found here: https://docs.google.com/document/d/1lUBRtOFLX9Zrkk7h4UarcYyol04B7kxFQ1Vj8fFzQN0/edit?ts=601f05bd
Trello planning document can be found here: https://trello.com/b/Xlee0ld6/blue-badge-final-project-ymca-database
Database Diagram can be found here: https://dbdiagram.io/d/601f049c80d742080a397618

Common Resources Referenced:
a. Resolving matching elements issue: https://stackoverflow.com/questions/58558258/sequence-contains-no-matching-element-c-sharp-web-api
b. Resolving NuGet package issue: https://stackoverflow.com/questions/22507189/could-not-load-file-or-assembly-newtonsoft-json-version-4-5-0-0-culture-neutr
c. Changing landing page for API: https://stackoverflow.com/questions/33891721/asp-net-webapi-default-landing-page
d. Resolving DbEntity validation errors: https://stackoverflow.com/questions/15820505/dbentityvalidationexception-how-can-i-easily-tell-what-caused-the-error

2.      Getting Started

The Web API utilizes .Net 4.8, Entity Framework 6.0, and Owin 2.3.3 and all dependents of those projects. A full list of dependencies can be found in the Web.Config file of the WebAPI Project in Github. The project uses Individual User Account authentication and will require account creation and auth values for requests.

3.      Usage and Endpoints

A local database must be created as the project is not hosted. Standard migrations can be employed to deploy the database and test functionality with an application such as Postman. Each Endpoint is categorized under the applicable data class. 

Note: Members. LocationID Foreign Key relationship must be set for CascadeDelete:False to Enable Migrations.

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

Location
POST api/Location
Add a new location to the database
GET api/Location/{id}
Request to show a single location by ID
GET api/Location
Request to show all locations in database
PUT api/Location/{id}
Update a Location in the database by ID
DELETE api/Location/{id}
Delete a Location in the database by ID

Instructor 
POST api/Instructor
Add a new instructor to the database
GET api/Instructor
Request to show all instructors
GET api/Instructor/{id}?instructorID={instructorID}
Request to show instructor by ID
GET api/Instructor/Location/{id}?locationID={locationID}
Request to show instructors by location ID
GET api/Instructor/Course/{id}?courseID={courseID}
Request to show instructors by course ID
PUT api/Instructor/{id}
Request to update an instructor by ID
DELETE api/Instructor/{id}?instructorID={instructorID}
Request to delete an instructor by ID

Seeder
GET api/seed
Runs the seed method to prepopulate database with information
DELETE api/clear
Clears user-entered data from database

4.      Roadmap

Please see the open issues portion of Github for any pending developing updates or known issues.

5.      Contributing

The project authors are Casey, Steve, and Andrew
