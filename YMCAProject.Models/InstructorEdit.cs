using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMCAProject.Data;

namespace YMCAProject.Models
{
    public class InstructorEdit
    {
        public int InstructorID { get; set; }
        public string InstructorName { get; set; }
        public Location Location { get; set; }
    }
}
