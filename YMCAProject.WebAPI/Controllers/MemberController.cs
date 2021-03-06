using Microsoft.AspNet.Identity;
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
    public class MemberController : ApiController
    {

        private MemberService CreateMemberService()
        {
            //var memberID = int.Parse(User.Identity.GetUserId());
            var MemberService = new MemberService();
            return MemberService;
        }
        [HttpGet]
        [Route("api/Member")]
        public IHttpActionResult GetAllMembers()
        {
            MemberService memberService = CreateMemberService();
            var members = memberService.GetMembers();
            return Ok(members);
        }
        [HttpPost]
        [Route("api/Member")]
        public IHttpActionResult Post (MemberCreate member)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMemberService();

            if (!service.CreateMember(member))
                return InternalServerError();

            return Ok("Member added!");
        }
        [HttpGet]
        [Route("api/Member/{id}")]
        public IHttpActionResult GetMemberByID([FromUri] int id)
        {
            MemberService memberService = CreateMemberService();
            var member = memberService.GetMemberByID(id);
            return Ok(member);
        }
        [HttpPut]
        [Route("api/Member/{id}")]
        public IHttpActionResult Put([FromBody] MemberEdit member)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateMemberService();

            if (!service.UpdateMember(member))
                return InternalServerError();

            return Ok("Member updated!");
        }
        [HttpDelete]
        [Route("api/Member/{id}")]
        public IHttpActionResult Delete (int id)
        {
            var service = CreateMemberService();

            if (!service.DeleteMember(id))
                return InternalServerError();

            return Ok("Member Deleted!");
        }
    }
}

