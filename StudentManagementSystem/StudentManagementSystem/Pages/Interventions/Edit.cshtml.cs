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
    public class EditModel : PageModel
    {
        private readonly StudentManagementSystem.Data.SMSData _context;

        public EditModel(StudentManagementSystem.Data.SMSData context)
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

            var intervention =  await _context.Intervention.FirstOrDefaultAsync(m => m.InterventionId == id);
            if (intervention == null)
            {
                return NotFound();
            }
            Intervention = intervention;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Intervention).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionExists(Intervention.InterventionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InterventionExists(int id)
        {
          return (_context.Intervention?.Any(e => e.InterventionId == id)).GetValueOrDefault();
        }
    }
}
