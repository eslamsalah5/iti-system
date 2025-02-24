using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ITIRazor.Models;
using ITIRazor.Data;


namespace ITIRazor.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; } = new List<Department>();

        public async Task OnGetAsync()
        {
            Department = await _context.Departments.Where(d => d.Status == true).ToListAsync();
        }
    }
}
