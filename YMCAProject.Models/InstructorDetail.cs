using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMCAProject.Data;

namespace YMCAProject.Models
{
    public class InstructorDetail
    {
        public int InstructorID { get; set; }
        public string InstrcutorName { get; set; }
        public Location Location { get; set; }
        public ICollection<Course> CoursesTaught { get; set; }
        public ICollection<Member> MembersTaught { get; set; }
    }
}
