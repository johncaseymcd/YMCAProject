using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Models
{
    public class InvoiceCreate
    {   
        [Required]
        public int InvocieID { get; set; }
        [Required]
        public int MemberID { get; set; }
        // public int InvoiceNumber { get; set; }
        [Required]
        public DateTimeOffset InvoiceDate { get; set; }
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