using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace StudentManagementSystem.Models
{
    public enum Category
    {
        Behavioural,
        Safeguarding,
        [Display(Name = "Extra Support")]
        ExtraSupport,
        Other
    }

    public class Intervention
    {
        [Display(Name = "Intervention ID")]
        public int InterventionId { get; set; }

        [Display(Name = "Date / Time"), Required]
        public DateTime Date { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required, StringLength(500)]
        public string Description { get; set; }

        [Required]
        public Student Student { get; set; }
    }
}
