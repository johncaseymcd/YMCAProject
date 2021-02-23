using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Models
{
    public class MemberListItem
    {
        [Required]
        public int MemberID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
