using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Models
{
    public class InvoiceEdit
    {
        public int InvoiceID { get; set; }
        // public int InvoiceNumber { get; set; }
        public string InvoiceDescription { get; set; }
        public DateTimeOffset InvoiceDueDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}