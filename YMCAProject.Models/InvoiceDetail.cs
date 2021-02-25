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
        public object InvoiceNumber { get; set; }
        public string InvoiceDescription { get; set; }
        public DateTime InvoiceDueDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        
        // Stretch Goal
        // public string LocationName { get; set; }
        //      
        // public string InstructorName { get; set; }
    }
}