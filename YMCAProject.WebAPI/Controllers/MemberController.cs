using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YMCAProject.Services;

namespace YMCAProject.WebAPI.Controllers
{
    public class MemberController : ApiController
    {
        private MemberService CreateMemberService()
        {
            var userID = User.Identity.GetUserId());
            var memberService = new MemberService(userID);
            return memberService;
        }
    }
}
