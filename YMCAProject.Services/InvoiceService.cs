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
            var entity =
                new Invoice()
                {
                    InvoiceID = model.InvoiceID,
                    // MemberID = model.MemberID,                
                    InvoiceDate = model.InvoiceDate,
                    InvoiceDescription = model.InvoiceDescription,
                    InvoiceDueDate = model.InvoiceDueDate,
                    InvoiceAmount = model.InvoiceAmount,
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
                var entity =
                    ctx
                    .Invoices

                    .Single(e => e.InvoiceID == invoiceID);
              
                return
                   new InvoiceDetail
                   {
                       InvoiceID = entity.InvoiceID,
                       // MemberID = entity.MemberID,                       
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
                            // MemberID = e.MemberID,                            
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
                                
                entity.InvoiceDescription = model.InvoiceDescription;
                entity.InvoiceDueDate = model.InvoiceDueDate;
                entity.InvoiceAmount = model.InvoiceAmount;
                entity.InvoiceIsPaid = model.InvoiceIsPaid;

                return ctx.SaveChanges() == 1;
            };
        }

      public bool DeleteInvoice(int invoiceID)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                      .Invoices
                      .Single(e => e.InvoiceID == invoiceID);


                ctx.Invoices.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}