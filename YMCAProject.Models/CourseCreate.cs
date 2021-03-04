using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMCAProject.Data;

namespace YMCAProject.Models
{
    public class CourseCreate
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseDescription { get; set; }
        [Required]
        public decimal CourseCost { get; set; }
        [Required]
        public int MaxCourseSize { get; set; }
        
        // Stretch goal
        [Required]
        public DateTime CourseStartDate { get; set; }
        [Required]
        public DateTime CourseEndDate { get; set; }

        // Stretch goal
        [Required]
        public int LocationID { get; set; }

        // Stretch goal
        [Required]
        public int InstructorID { get; set; }
    }
}
