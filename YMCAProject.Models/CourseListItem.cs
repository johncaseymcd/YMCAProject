using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Models
{
    public class CourseListItem
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public decimal CourseCost { get; set; }
        public int MaxCourseSize { get; set; }
        public bool HasAvailability { get; set; }

        // Stretch goal
        // public string InstructorName { get; set; }

        // Stretch goal 
        // public string LocationName { get; set; }
    }
}
