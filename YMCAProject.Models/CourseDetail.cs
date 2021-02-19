using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMCAProject.Data;

namespace YMCAProject.Models
{
    public class CourseDetail
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public decimal CourseCost { get; set; }
        public int MaxCourseSize { get; set; }
        public bool HasAvailability { get; set; }
        public ICollection<Member> CourseMembers { get; set; }
        
        // Stretch goal
        // public string LocationName { get; set; }

        // Stretch goal
        // public string InstructorName { get; set; }
    }
}
