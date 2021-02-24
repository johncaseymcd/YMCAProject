using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Models
{
    public class MemberDetail
    {
        public int MemberID { get; set; }
        public DateTime DateJoined { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        //public virtual List<Course> CoursesTaken = new List<Course>() { get; set; }
        //public virtual List<Invoice> Invoices = new List<Invoice>() { get; set; }
        public long CreditCardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public int SecurityCode { get; set; }
    }
}
