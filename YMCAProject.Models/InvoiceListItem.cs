using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMCAProject.Data;

namespace YMCAProject.Models
{
    public class InvoiceListItem
    {
        public int InvoiceID { get; set; }           
        public string InvoiceDescription { get; set; }
        public DateTimeOffset InvoiceDueDate { get; set; }
        public decimal MonthlyFee { get; set; }
        public decimal InvoiceAmount { get; set; }
        public bool InvoiceIsPaid { get; set; }        
    }
}