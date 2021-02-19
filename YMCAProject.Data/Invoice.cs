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
        public object InvoiceNumber { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public string InvoiceDescription { get; set; }
        [Required]
        public DateTime InvoiceDueDate { get; set; }
        [Required]
        public decimal InvoiceAmount { get; set; }
        [Required] 
        public bool InvoiceIsPaid { get; set; }

        // Stretch Goal
        // [Required|
        // Public virtual List<Course> Course { get; set; }
    }
}

