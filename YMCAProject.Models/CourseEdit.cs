using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Models
{
    public class CourseEdit
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public decimal CourseCost { get; set; }
        public int MaxCourseSize { get; set; }

        // Stretch goal
        // public DateTime CourseStartDate { get; set; }
        // public DateTime CourseEndDate { get; set; }

        // Stretch goal
        // public Location Location { get; set; }

        // Stretch goal
        // public Instructor Instructor { get; set; }
    }
}
