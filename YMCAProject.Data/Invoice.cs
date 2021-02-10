using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Data
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
                
        [Required]
        [ForeignKey(nameof(Members))]
        public int MemberID { get; set; }
        public virtual Member Members { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }

        //public virtual List<Course> Course { get; set; } = new List<Course>();

        [Required]
        public decimal Amount { get; set; }

        //Public bool IsPaid
    }
}