﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMCAProject.Data;
using YMCAProject.Models;
using YMCAProject.WebAPI.Data;

namespace YMCAProject.Services
{
    public class MemberService
    {
        private readonly int _memberID;

        public MemberService(int memberID)
        {
            _memberID = memberID;
        }
        public bool CreateMember(MemberCreate model)
        {
            var entity =
                new Member()
                {
                    MemberID = _memberID,
                    DateJoined = model.DateJoined,
                    Name = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Members.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MemberListItem> GetMembers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Members
                    .Where(e => e.MemberID == _memberID)
                    .Select(
                       e =>
                       new MemberListItem
                       {
                           MemberID = e.MemberID,
                           Name = e.Name
                       }
                       );
                return query.ToArray();
            }
        }
        public MemberDetail GetMemberByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Members
                    .Single(e => e.MemberID == id && e.MemberID == _memberID);
                return
                    new MemberDetail
                    {
                        MemberID = entity.MemberID,
                        DateJoined = entity.DateJoined,
                        Name = entity.Name,
                        Email = entity.Email,
                        Address = entity.Address,
                        PhoneNumber = entity.PhoneNumber,
                        CreditCardNumber = entity.CreditCardNumber,
                        ExpirationDate = entity.ExpirationDate,
                        SecurityCode = entity.SecurityCode,
                    };
            }
        }
        public bool UpdateMember (MemberEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Members
                    .Single(e => e.MemberID == model.MemberID && e.MemberID == _memberID);
                entity.MemberID = model.MemberID;
                entity.Name = model.Name;
                entity.Email = model.Email;
                entity.Address = model.Address;
                entity.PhoneNumber = model.PhoneNumber;
                entity.CreditCardNumber = model.CreditCardNumber;
                entity.ExpirationDate = model.ExpirationDate;
                entity.SecurityCode = model.SecurityCode;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteMember (int memberID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Members
                    .Single(e => e.MemberID == memberID && e.MemberID == _memberID);

                ctx.Members.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}