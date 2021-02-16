using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace YMCAProject.Data
{
    public class Member
    {
        [Required]
        public int MemberID { get; set; }
        [Required] 
        public DateTime DateJoined { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required] 
        public string Email { get; set; }
        [Required] 
        public string Address { get; set; }
        [Required] 
        public string PhoneNumber { get; set; }
        //public virtual List<Course> CoursesTaken = new List<Course>() { get; set; }
        //public virtual List<Invoice> Invoices = new List<Invoice>() { get; set; }
        public long CreditCardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public int SecurityCode { get; set; }
    }
}
