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
        private readonly int _invoiceID;

        public InvoiceService(int invoiceID)
        {
            _invoiceID = invoiceID;
        }

        public InvoiceService()
        {
        }

        public bool CreateInvoice(InvoiceCreate model)
        {
            var entity = new Invoice()
            {
                InvoiceID = _invoiceID,
                InvoiceNumber = model.InvoiceNumber,
                InvoiceDate = model.InvoiceDate,
                InvoiceDescription = model.InvoiceDescription,
                InvoiceDueDate = model.InvoiceDueDate,
                InvoiceAmount = model.InvoiceAmount,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Invoices.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InvoiceListItem> GetInvoices()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Invoices
                    .Where(e => e.InvoiceID == _invoiceID)
                    .Select(
                        e => new InvoiceListItem
                        {
                            InvoiceID = e.InvoiceID,
                            InvoiceNumber = (string)e.InvoiceNumber,                            
                            InvoiceDueDate = e.InvoiceDueDate,
                            InvoiceAmount = e.InvoiceAmount
                        }
                    );

                return query.ToArray();
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
                       InvoiceNumber = entity.InvoiceNumber,
                       InvoiceDescription = entity.InvoiceDescription,
                       InvoiceDueDate = entity.InvoiceDueDate,
                       InvoiceAmount = entity.InvoiceAmount,
                   };
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
                    entity.InvoiceID = entity.InvoiceID;
                    entity.InvoiceNumber = entity.InvoiceNumber;
                    entity.InvoiceDate = entity.InvoiceDate;
                    entity.InvoiceDescription = entity.InvoiceDescription;
                    entity.InvoiceDueDate = entity.InvoiceDueDate;
                    entity.InvoiceAmount = entity.InvoiceAmount;

                    return ctx.SaveChanges() == 1;
            };
        }

        public bool DeleteInvoice(int _invoiceID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                .Invoices
                .Single(e => e.InvoiceID == _invoiceID);

                ctx.Invoices.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}