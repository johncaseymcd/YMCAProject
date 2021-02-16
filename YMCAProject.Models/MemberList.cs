using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Models
{
    public class MemberList
    {
        [Required]
        public int MemberID { get; set; }
        public string Name { get; set; }
    }
}
