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
        [Required]
        public string LocationName { get; set; }
        [Required]
        public string LocationAddress { get; set; }
        [Required]
        public string LocationPhoneNumber { get; set; }
        [Required]
        public string LocationEmail { get; set; }
    }
}