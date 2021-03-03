using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Data
{
    public class Instructor
    {
        [Key]
        public int InstructorID { get; set; }
        [Required]
        public string InstructorName { get; set; }
        
        [ForeignKey(nameof(Location))]
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }

        public ICollection<Course> CoursesTaught { get; set; } = new List<Course>();
        public ICollection<Member> MembersTaught
        {
            get
            {
                var members = new List<Member>();
                foreach(var course in CoursesTaught)
                {
                    foreach(var member in course.ListOfMembers)
                    {
                        members.Add(member);
                    }
                }
                return members;
            }

            set { }
        }

        public Instructor()
        {
            CoursesTaught = new HashSet<Course>();
        }
    }
}
