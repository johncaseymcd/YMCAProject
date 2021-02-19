using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Models
{
    public class InvoiceEdit
    {
        public int InvoiceID { get; set; }
        public object InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceDescription { get; set; }
        public decimal InvoiceAmount { get; set; }
    }
}