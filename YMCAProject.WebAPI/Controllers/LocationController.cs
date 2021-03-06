using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using YMCAProject.Models;
using YMCAProject.Services;

namespace YMCAProject.WebAPI.Controllers
{
    public class LocationController : ApiController
    {
        [HttpPost]
        [Route("api/Location")]
        public IHttpActionResult PostLocation([FromBody] LocationCreate location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new LocationService();

            if (!service.CreateLocation(location))
                return InternalServerError();

            return Ok("Location successfully added.");
        }

        [HttpGet]
        [Route("api/Location/{id}")]
        public IHttpActionResult GetLocationByID([FromUri] int id)
        {
            var service = new LocationService();
            var location = service.GetLocationByID(id);
            return Ok(location);
        }

        [HttpGet]
        [Route("api/Location")]
        public IHttpActionResult GetAllLocations()
        {
            var service = new LocationService();
            var locationList = service.GetAllLocations();
            return Ok(locationList);
        }

        [HttpPut]
        [Route("api/Location/{id}")]
        public IHttpActionResult PutLocation([FromBody] LocationEdit location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new LocationService();

            if (!service.UpdateLocation(location))
                return InternalServerError();

            return Ok("Location successfully updated.");
        }

        [HttpDelete]
        [Route("api/Location/{id}")]
        public IHttpActionResult Delete(int id)

        {
            var service = new LocationService();
            if (!service.DeleteLocation(id))
                return InternalServerError();

            return Ok("Location successfully deleted.");
        }
    }
}