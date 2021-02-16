using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Data
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        [Required]
        public decimal Cost { get; set; }
        
        // Stretch goal?
        // ------------
        // [ForeignKey(nameof(Location))]
        // public int LocationID { get; set; }
        // public virtual Location Location { get; set; }

        // Stretch goal?
        // ------------
        // [ForeignKey(nameof(Instructor))]
        // public int InstructorID { get; set; }
        // public virtual Instructor Instructor { get; set; }

        public List<Member> Members { get; set; }
    }
}
