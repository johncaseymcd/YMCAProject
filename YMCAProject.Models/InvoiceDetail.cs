using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Models
{
    public class InvoiceDetail
    {
        public int InvoiceID { get; set; }
        public int MemberID { get; set; }
        // public int InvoiceNumber { get; set; }
        public DateTimeOffset InvoiceDate { get; set; }
        public string InvoiceDescription { get; set; }
        public DateTimeOffset InvoiceDueDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public bool InvoiceIsPaid { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}