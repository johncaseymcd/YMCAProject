using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Models
{
    public class CourseCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public int MaxCourseSize { get; set; }

        // Stretch goal
        // [Required]
        // public int LocationID { get; set; }

        // Stretch goal
        // [Required]
        // public int InstructorID { get; set; }
    }
}
