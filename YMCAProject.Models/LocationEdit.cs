using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Models
{
    public class LocationEdit
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int LocationStreetNumber { get; set; }
        public string LocationStreetName { get; set; }
        public string LocationCity { get; set; }
        public string LocationState { get; set; }
        public int LocationZipCode { get; set; }
        public string LocationPhoneNumber { get; set; }
        public string LocationEmail { get; set; }
    }
}
