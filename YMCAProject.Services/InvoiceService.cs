using System;
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
                // InvoiceNumber = model.InvoiceNumber,
                InvoiceDate = model.InvoiceDate,
                InvoiceDescription = model.InvoiceDescription,
                InvoiceDueDate = model.InvoiceDueDate,
                InvoiceAmount = model.InvoiceAmount,
                InvoiceIsPaid = model.InvoiceIsPaid,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Invoices.Add(entity);
                return ctx.SaveChanges() == 1; // Look up what 0 and 1 due
            }
        }
                        
        public InvoiceDetail GetInvoiceByID(int InvoiceID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Invoices
                    .Single(e => e.InvoiceID == InvoiceID);
                return
                   new InvoiceDetail
                   {
                       InvoiceID = entity.InvoiceID,
                       MemberID = entity.MemberID,
                       // InvoiceNumber = entity.InvoiceNumber,
                       InvoiceDate = entity.InvoiceDate,
                       InvoiceDescription = entity.InvoiceDescription,
                       InvoiceDueDate = entity.InvoiceDueDate,
                       InvoiceAmount = entity.InvoiceAmount,
                       InvoiceIsPaid = entity.InvoiceIsPaid,
                   };
            }
        }

        public IEnumerable<InvoiceListItem> GetAllInvoices()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Invoices
                    .Select(
                        e => new InvoiceListItem
                        {                           
                            InvoiceID = e.InvoiceID,
                            MemberID = e.MemberID,
                            // InvoiceNumber = e.InvoiceNumber,
                            InvoiceDate = e.InvoiceDate,
                            InvoiceDescription = e.InvoiceDescription,
                            InvoiceDueDate = e.InvoiceDueDate,
                            InvoiceAmount = e.InvoiceAmount,
                            InvoiceIsPaid = e.InvoiceIsPaid,
                            CreatedUtc = e.CreatedUtc,
                            ModifiedUtc = e.ModifiedUtc,
                        }
                    );

                return query.ToArray();
            }
        }

        public bool UpdateInvoice(InvoiceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Invoices
                    .Single(e => e.InvoiceID == model.InvoiceID);
                entity.MemberID = entity.MemberID;
                // entity.InvoiceNumber = entity.InvoiceNumber;
                entity.InvoiceDate = entity.InvoiceDate;
                entity.InvoiceDescription = entity.InvoiceDescription;
                entity.InvoiceDueDate = entity.InvoiceDueDate;
                entity.InvoiceAmount = entity.InvoiceAmount;
                entity.InvoiceIsPaid = entity.InvoiceIsPaid;

                return ctx.SaveChanges() == 1;
            };
        }

        public bool DeleteInvoice(int InvoiceID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                .Invoices
                .Single(e => e.InvoiceID == InvoiceID);

                ctx.Invoices.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}