using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMCAProject.Data;
using YMCAProject.Models;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace YMCAProject.Services
{
    public class MemberService
    {
        private readonly int _userID;

        public MemberService(int userID)

        {
            _userID = userID;
        }
        public bool CreateNote(MemberCreate model)
        {
            var entity =
                new Member()
                {
                    MemberID = _userID,
                    DateJoined = model.DateJoined,
                    Name = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Member.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
