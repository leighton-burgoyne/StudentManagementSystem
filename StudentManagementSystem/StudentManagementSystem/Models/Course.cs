using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public enum Level
    {
        GCSE,
        [Display(Name = "Level 1")]
        Level1,
        [Display(Name = "Level 2")]
        Level2,
        [Display(Name = "Level 3")]
        Level3,
        Degree,
        Other
    }
    public class Course
    {
        [Display(Name = "ID")]
        public int CourseId { get; set; }

        [Display(Name = "Code")]
        public string Code { get; set; }

        [StringLength(20), Required]
        public string Name { get; set; }


        [Required]
        public double Cost { get; set; }
        
        [Required]
        public Level Level { get; set; }

        [Required]
        public int Credits { get; set; }

        [Required]
        public int GLH { get; set; }

        [Display(Name = "Exam Board"), StringLength(100), Required]
        public string ExamBoard { get; set; }

        [Display(Name = "Start Date"), Required]
        public DateTime StartDate { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }
    }
}
