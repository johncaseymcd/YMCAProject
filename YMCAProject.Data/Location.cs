﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Data
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        public virtual ICollection<Member> ListOfMembers { get; set; } = new List<Member>();
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

        public Location()
        {
            ListOfMembers = new HashSet<Member>();
        }
    }
}