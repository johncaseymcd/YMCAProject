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
    class InvoiceService
    {
        public bool CreateInvoice(InvoiceCreate model)
        {
            var entity =
                new Invoice()
                {
                    MemberID = _memberID,
                    InvoiceDate = model.InvoiceDate,
                    DueDate = model.DueDate,
                    Amount = model.Amount,
                    Invoice = model.Invoice
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

                var query =
                    ctx
                        .Invoices
                        .Where(e => e.MemberID == _memberID)
                        .Select(
                            e =>
                                new InvoiceListItem
                                {
                                    InvoiceID = e.InvoiceID,
                                    Invoice = e.Invocie,
                                    DueData = e.DueDate
                                }
                        );

            return query.ToArray();
        }
    }

    public NoteDetail GetNoteById(int id)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                    .Notes
                    .Single(e => e.NoteId == id && e.OwnerId == _userId);
            return
                new NoteDetail
                {
                    NoteId = entity.NoteId,
                    Title = entity.Title,
                    Content = entity.Content,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
        }
    }

    public bool UpdateNote(NoteEdit model)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                    .Notes
                    .Single(e => e.NoteId == model.NoteId && e.OwnerId == _userId);

            entity.Title = model.Title;
            entity.Content = model.Content;
            entity.ModifiedUtc = DateTimeOffset.UtcNow;

            return ctx.SaveChanges() == 1;
        }
    }

    public bool DeleteNote(int noteId)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                    .Notes
                    .Single(e => e.NoteId == noteId && e.OwnerId == _userId);

            ctx.Notes.Remove(entity);

            return ctx.SaveChanges() == 1;
        }
    }
}
}




