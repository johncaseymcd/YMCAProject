using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMCAProject.Data;

namespace YMCAProject.Models
{
    public class InvoiceDetail
    {
        public int InvoiceID { get; set; }
        public int MemberID { get; set; }
        public string InvoiceDescription { get; set; }
        public List<string> CoursesTaken { get; set; }
        public DateTimeOffset InvoiceDueDate { get; set; }
        public decimal MonthlyFee { get; set; }
        public decimal InvoiceAmount { get; set; }
        public bool InvoiceIsPaid { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}