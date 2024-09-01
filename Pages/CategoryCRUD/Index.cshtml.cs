using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AtulaDotNetTest.Model;

namespace AtulaDotNetTest.Pages.CategoryCRUD
{
    public class IndexModel : PageModel
    {
        private readonly AtulaDotNetTest.Model.WebAppContext _context;

        public IndexModel(AtulaDotNetTest.Model.WebAppContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
