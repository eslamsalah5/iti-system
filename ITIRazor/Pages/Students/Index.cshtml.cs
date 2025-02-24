using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ITIRazor.Data;
using ITIRazor.Models;

namespace ITIRazor.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ITIRazor.Data.AppDbContext _context;

        public IndexModel(ITIRazor.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Students
                .Include(s => s.Dept).ToListAsync();
        }
    }
}
