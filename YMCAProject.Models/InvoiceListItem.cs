using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Models
{
    public class InvoiceListItem
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal InvoiceAmount { get; set; }
        public DateTime InvoiceDueDate { get; set; }
        public bool InvoiceIsPaid { get; set; }
    }
}