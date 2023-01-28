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
    public class IndexModel : PageModel
    {
        private readonly StudentManagementSystem.Data.SMSData _context;

        public IndexModel(StudentManagementSystem.Data.SMSData context)
        {
            _context = context;
        }

        public IList<Intervention> Intervention { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Intervention != null)
            {
                Intervention = await _context.Intervention.ToListAsync();
            }
        }
    }
}
