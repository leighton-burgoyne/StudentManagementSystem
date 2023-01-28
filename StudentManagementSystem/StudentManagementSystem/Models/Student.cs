using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace StudentManagementSystem.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other,
    }

    public class Student
    {
        [Display(Name = "ID Number")]
        public int StudentId { get; set; }

        [Display(Name = "Enrolment Date")]
        public DateTime EnrolmentDate { get; set; }

        [Display(Name = "First Name"), StringLength(20), Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name"), StringLength(20), Required]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth"), Required]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Personal Email"), StringLength(100), Required]
        public string PersonalEmail { get; set; }

        [Display(Name = "Mobile Telephone"), StringLength(15), Required]
        public string MobileTelephoneNumber { get; set; }

        [Display(Name = "Home Telephone"), StringLength(15), Required]
        public string HomeTelephoneNumber { get; set; }

        [Display(Name = "Gender"), Required]
        public Gender StudentGender { get; set; }

        [Display(Name = "Looked After Child"), Required]
        public bool IsLookedAfterChild { get; set; }

        [Display(Name = "Care Leaver"), Required]
        public bool IsCareLeaver { get; set; }

        [Display(Name = "Additional Needs"), Required]
        public bool HasAdditionalNeeds { get; set; }

        [Display(Name = "Address Line 1"), StringLength(30), Required]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2"), StringLength(30)]
        public string AddressLine2 { get; set; }

        [Display(Name = "Postcode"), StringLength(9), Required]
        public string AddressPostcode { get; set; }

        [Display(Name = "NI Number"), StringLength(9), Required]
        public string NiNumber { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }
    }
}
