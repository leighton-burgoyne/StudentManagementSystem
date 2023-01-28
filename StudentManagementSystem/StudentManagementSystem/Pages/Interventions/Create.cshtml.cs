using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Interventions
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
        public Intervention Intervention { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Intervention == null || Intervention == null)
            {
                return Page();
            }

            _context.Intervention.Add(Intervention);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
