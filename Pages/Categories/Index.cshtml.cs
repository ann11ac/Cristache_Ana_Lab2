using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cristache_Ana_Lab2.Data;
using Cristache_Ana_Lab2.Models;

namespace Cristache_Ana_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Cristache_Ana_Lab2.Data.Cristache_Ana_Lab2Context _context;

        public IndexModel(Cristache_Ana_Lab2.Data.Cristache_Ana_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
