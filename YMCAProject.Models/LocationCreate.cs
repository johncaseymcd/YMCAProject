using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Models
{
    public class LocationCreate
    {
        //[Required]
        //public int LocationID { get; set; }
        [Required]
        public string LocationName { get; set; }
        [Required]
        public int LocationStreetNumber { get; set; }
        [Required]
        public string LocationStreetName { get; set; }
        [Required]
        public string LocationCity { get; set; }
        [Required]
        public string LocationState { get; set; }
        [Required]
        public int LocationZipCode { get; set; }
        [Required]
        public string LocationPhoneNumber { get; set; }
        [Required]
        public string LocationEmail { get; set; }
    }
}