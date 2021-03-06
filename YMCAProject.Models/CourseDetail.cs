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
        public ICollection<Member> ListOfMembers { get; set; }

        // Stretch goal
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }
        public bool IsCurrentlyRunning { get; set; }

        // Stretch goal
        public int LocationID { get; set; }

        // Stretch goal
        public int InstructorID { get; set; }
    }
}
