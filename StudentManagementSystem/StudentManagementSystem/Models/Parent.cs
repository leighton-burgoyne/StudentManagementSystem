using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Parent
    {
        [Display(Name = "ID")]
        public int ParentId { get; set; }

        [StringLength(20), Required]
        public string FirstName { get; set; }

        [StringLength(20), Required]
        public string LastName { get; set; }

        [StringLength(100), Required]
        public string ParentalEmail { get; set; }

        [StringLength(15), Required]
        public string MobileTelephoneNumber { get; set; }

        [Required]
        public bool IsEmergencyContact { get; set; }

        [StringLength(20), Required]
        public string AddressLine1 { get; set; }

        [StringLength(20), Required]
        public string AddressLine2 { get; set; }

        [StringLength(9), Required]
        public string AddressPostcode { get; set; }
    }
}
