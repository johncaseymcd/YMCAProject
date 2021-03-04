using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Models
{
    public class InstructorCreate
    {
        [Required]
        public int InstructorID { get; set; }
        [Required]
        public string InstructorName { get; set; }
        [Required]
        public int LocationID { get; set; }
    }
}
