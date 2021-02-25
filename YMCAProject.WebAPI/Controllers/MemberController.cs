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
            var memberID = int.Parse(User.Identity.GetUserId());
            var MemberService = new MemberService(memberID);
            return MemberService;
        }

        public IHttpActionResult Get()
        {
            MemberService memberService = CreateMemberService();
            var members = memberService.GetMembers();
            return Ok(members);
        }
        public IHttpActionResult Post (MemberCreate member)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMemberService();

            if (!service.CreateMember(member))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            MemberService memberService = CreateMemberService();
            var member = memberService.GetMemberByID(id);
            return Ok(member);
        }
        public IHttpActionResult Put(MemberEdit member)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateMemberService();

            if (!service.UpdateMember(member))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete (int id)
        {
            var service = CreateMemberService();

            if (!service.DeleteMember(id))
                return InternalServerError();

            return Ok();
        }
    }
}

