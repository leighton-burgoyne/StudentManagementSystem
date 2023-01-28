using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Students
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly StudentManagementSystem.Data.SMSData _context;

        public CreateModel(StudentManagementSystem.Data.SMSData context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Student == null || Student == null)
            {
                return Page();
            }
            //Student.DisplayName = "( " + Student.StudentId + " ) " + Student.FirstName + " " + Student.LastName;
            Student.EnrolmentDate = DateTime.Now;
            _context.Student.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
