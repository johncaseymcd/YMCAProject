using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMCAProject.Data;

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
        public virtual List<Course> CoursesTaken { get; set; } = new List<Course>();
        public virtual List<Invoice> Invoices { get; set; } = new List<Invoice>();
        public long CreditCardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public int SecurityCode { get; set; }
        public int LocationID { get; set; }
    }
}
