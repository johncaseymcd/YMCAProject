using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Data
{
    public class Location
    {
        public int LocationID { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

        public Location()
        {
            Instructors = new HashSet<Instructor>();
        }
    }
}
