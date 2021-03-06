﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMCAProject.Data
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        [ForeignKey(nameof(Member))]
        public int MemberID { get; set; }
        public virtual Member Member { get; set; }
        [Required]
        public string InvoiceDescription { get; set; }
        public virtual List<Course> CoursesTaken { get; set; } = new List<Course>();
        [Required]
        public DateTimeOffset InvoiceDueDate { get; set; }
        [Required]
        public decimal MonthlyFee { get; set; }

        public decimal InvoiceAmount
        {
            get
            {
                decimal courseTotal = 0;
                foreach (var course in CoursesTaken)
                {
                    courseTotal += course.CourseCost;
                }

                decimal totalAmount = (courseTotal + MonthlyFee) * 1.07m;

                return totalAmount;                     
            }

            set { }
        }
        public bool InvoiceIsPaid { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}