using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AtulaDotNetTest.Model;

namespace AtulaDotNetTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AtulaDotNetTest.Model.WebAppContext _context;

        public IndexModel(AtulaDotNetTest.Model.WebAppContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
