using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Module
    {
        [Display(Name = "ID")]
        public int ModuleId { get; set; }

        [StringLength(20), Required]
        public string Name { get; set; }

        [StringLength(4), Required]
        public int Credits { get; set; }

        [StringLength(4), Required]
        public int GLH { get; set; }

        public Course Course { get; set; }
    }
}
