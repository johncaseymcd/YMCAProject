using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YMCAProject.Models;
using YMCAProject.Services;

namespace YMCAProject.WebAPI.Controllers
{
    public class InstructorController : ApiController
    {
        [HttpPost]
        [Route("api/Instructor")]
        public IHttpActionResult PostInstructor([FromBody] InstructorCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var svc = new InstructorService();

            if (!svc.CreateInstructor(model))
                return InternalServerError();

            return Ok("Instructor successfully added.");
        }

        [HttpGet]
        [Route("api/Instructor")]
        public IHttpActionResult GetAllInstructors()
        {
            var svc = new InstructorService();
            var instructors = svc.GetAllInstructors();
            return Ok(instructors);
        }

        [HttpGet]
        [Route("api/Instructor/{id}")]
        public IHttpActionResult GetInstructorByID([FromUri] int instructorID)
        {
            var svc = new InstructorService();
            var instructor = svc.GetInstructorByID(instructorID);
            return Ok(instructor);
        }

        [HttpGet]
        [Route("api/Instructor/Location/{id}")]
        public IHttpActionResult GetInstructorsByLocation([FromUri] int locationID)
        {
            var svc = new InstructorService();
            var instructors = svc.GetInstructorsByLocation(locationID);
            return Ok(instructors);
        }

        [HttpGet]
        [Route("api/Instructor/Course/{id}")]
        public IHttpActionResult GetInstructorsByCourse([FromUri] int courseID)
        {
            var svc = new InstructorService();
            var instructors = svc.GetInstructorsByCourse(courseID);
            return Ok(instructors);
        }

        [HttpPut]
        [Route("api/Instructor/{id}")]
        public IHttpActionResult UpdateInstructor([FromBody] InstructorEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var svc = new InstructorService();

            if (!svc.UpdateInstructor(model))
                return InternalServerError();

            return Ok("Instructor successfully updated.");
        }

        [HttpDelete]
        [Route("api/Instructor/{id}")]
        public IHttpActionResult DeleteInstructor([FromUri] int instructorID)
        {
            var svc = new InstructorService();
            if (!svc.DeleteInstructor(instructorID))
                return InternalServerError();
            return Ok("Instructor successfully deleted.");
        }
    }
}
