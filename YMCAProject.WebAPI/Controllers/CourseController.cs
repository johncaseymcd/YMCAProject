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
    public class CourseController : ApiController
    {
        [HttpPost]
        [Route("api/Course")]
        public IHttpActionResult PostCourse([FromBody] CourseCreate course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new CourseService();

            if (!service.CreateCourse(course))
                return InternalServerError();

            return Ok("Course successfully added.");
        }

        [HttpGet]
        [Route("api/Course")]
        public IHttpActionResult GetAllCourses()
        {
            var service = new CourseService();
            var courseList = service.GetAllCourses();
            return Ok(courseList);
        }

        [HttpGet]
        [Route("api/Course/{id}")]
        public IHttpActionResult GetCourseByID([FromUri] int id)
        {
            var service = new CourseService();
            var course = service.GetCourseByID(id);
            return Ok(course);
        }

        [HttpGet]
        [Route("api/Course/open")]
        public IHttpActionResult GetOpenCourses()
        {
            var service = new CourseService();
            var courseList = service.GetOpenCourses();
            return Ok(courseList);
        }

        // Stretch goal
        // ------------
        [HttpGet]
        [Route("api/Course/Current")]
        public IHttpActionResult GetCurrentCourses()
        {
            var service = new CourseService();
            var courseList = service.GetCurrentCourses();
            return Ok(courseList);
        }



        // Stretch goal
        // ------------
        [HttpGet]
        [Route("api/Course/Instructor/{id}")]
        public IHttpActionResult GetCoursesByInstructor([FromUri] int instructorID)
        {
            var service = new CourseService();
            var courseList = service.GetCoursesByInstructor(instructorID);
            return Ok(courseList);
        }



        // Stretch goal
        // ------------
        [HttpGet]
        [Route("api/Course/Location/{id}")]
        public IHttpActionResult GetCoursesByLocation([FromUri] int locationID)
        {
            var service = new CourseService();
            var courseList = service.GetCoursesByLocation(locationID);
            return Ok(courseList);
        }

        [HttpPut]
        [Route("api/Course/{id}")]
        public IHttpActionResult PutCourse([FromBody] CourseEdit course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new CourseService();

            if (!service.UpdateCourse(course))
                return InternalServerError();

            return Ok("Course successfully updated.");
        }

        [HttpDelete]
        [Route("api/Course/{id}")]
        public IHttpActionResult DeleteCourse([FromUri] int id)
        {
            var service = new CourseService();
            if (!service.DeleteCourse(id))
                return InternalServerError();

            return Ok("Course successfully deleted.");
        }
    }
}
