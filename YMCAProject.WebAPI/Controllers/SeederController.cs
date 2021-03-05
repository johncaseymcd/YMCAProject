using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YMCAProject.Services;

namespace YMCAProject.WebAPI.Controllers
{
    public class SeederController : ApiController
    {
        [HttpGet]
        [Route("api/seed")]
        public IHttpActionResult SeedDatabase()
        {
            var svc = new SeederService();
            if (!svc.SeedDatabase())
                return InternalServerError();
            return Ok("Database contents successfully pre-filled.");
        }

        [HttpDelete]
        [Route("api/clear")]
        public IHttpActionResult ClearDatabase()
        {
            var svc = new SeederService();
            if (!svc.ClearDatabase())
                return InternalServerError();
            return Ok("Database contents successfully cleared.");
        }
    }
}
