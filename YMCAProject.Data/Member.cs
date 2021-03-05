using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YMCAProject.Data
{
    public class Member
    {
        [Key]
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
        public virtual List<Course> CoursesTaken { get; set; } = new List<Course>();
        public virtual List<Invoice> Invoices { get; set; } = new List<Invoice>();
        public long CreditCardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public int SecurityCode { get; set; }
        [ForeignKey(nameof(Location))]
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }
    }
}