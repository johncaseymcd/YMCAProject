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
        public string InstructorName { get; set; }
        public int LocationID { get; set; }
        public List<string> CoursesTaught { get; set; }
        public List<string> MembersTaught { get; set; }
    }
}
