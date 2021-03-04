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
    public class InvoiceCreate
    {
        [Required]
        public int MemberID { get; set; } 
        [Required]
        [MaxLength(70, ErrorMessage = "Number of characters exceeded.")]
        public string InvoiceDescription { get; set; }
        [Required]
        public DateTimeOffset InvoiceDueDate { get; set; }
        [Required]
        public decimal InvoiceAmount { get; set; }
        [Required]
        public bool InvoiceIsPaid { get; set; }
    }
}