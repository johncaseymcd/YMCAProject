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

    public class InvoiceService
    {

        public bool CreateInvoice(InvoiceCreate model)
        {
            var entity = new Invoice()
            {
                MemberID = model.MemberID,
                InvoiceDescription = model.InvoiceDescription,
                InvoiceDueDate = model.InvoiceDueDate,
                MonthlyFee = model.MonthlyFee,
                InvoiceIsPaid = model.InvoiceIsPaid,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Invoices.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public InvoiceDetail GetInvoiceByID(int invoiceID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Invoices
                    .Single(e => e.InvoiceID == invoiceID);
                var courseNames = new List<string>();
                foreach(var course in entity.CoursesTaken)
                {
                    courseNames.Add(course.CourseName);
                }
                return
                   new InvoiceDetail
                   {
                       InvoiceDescription = entity.InvoiceDescription,
                       CoursesTaken = courseNames,
                       InvoiceDueDate = entity.InvoiceDueDate,
                       MonthlyFee = entity.MonthlyFee,
                       InvoiceAmount = entity.InvoiceAmount,
                       InvoiceIsPaid = entity.InvoiceIsPaid,
                       CreatedUtc = entity.CreatedUtc,
                       ModifiedUtc = entity.ModifiedUtc,
                   };
            }
        }

        public IEnumerable<InvoiceListItem> GetAllInvoices()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Invoices
                    .Select(
                        e => new InvoiceListItem

                        {
                            InvoiceID = e.InvoiceID,
                            InvoiceDescription = e.InvoiceDescription,                            
                            InvoiceDueDate = e.InvoiceDueDate,
                            MonthlyFee = e.MonthlyFee,
                            InvoiceAmount = e.InvoiceAmount,
                            InvoiceIsPaid = e.InvoiceIsPaid,                            
                        }
                    );
                return query.ToArray();
            }
        }

        public bool UpdateInvoice(InvoiceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Invoices
                    .Single(e => e.InvoiceID == model.InvoiceID);
                                
                entity.InvoiceDescription = model.InvoiceDescription;
                entity.InvoiceDueDate = model.InvoiceDueDate;
                entity.MonthlyFee = model.MonthlyFee;
                entity.InvoiceAmount = model.InvoiceAmount;
                entity.InvoiceIsPaid = model.InvoiceIsPaid;               

                return ctx.SaveChanges() == 1;
            };
        }

        public bool DeleteInvoice(int invoiceID)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Invoices
                    .Single(e => e.InvoiceID == invoiceID);
                
                ctx.Invoices.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}