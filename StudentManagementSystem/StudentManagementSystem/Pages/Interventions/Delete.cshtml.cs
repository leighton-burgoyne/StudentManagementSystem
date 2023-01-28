using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Pages.Interventions
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly StudentManagementSystem.Data.SMSData _context;

        public DeleteModel(StudentManagementSystem.Data.SMSData context)
        {
            _context = context;
        }

        [BindProperty]
      public Intervention Intervention { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Intervention == null)
            {
                return NotFound();
            }

            var intervention = await _context.Intervention.FirstOrDefaultAsync(m => m.InterventionId == id);

            if (intervention == null)
            {
                return NotFound();
            }
            else 
            {
                Intervention = intervention;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Intervention == null)
            {
                return NotFound();
            }
            var intervention = await _context.Intervention.FindAsync(id);

            if (intervention != null)
            {
                Intervention = intervention;
                _context.Intervention.Remove(Intervention);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
