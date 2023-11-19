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
        public IList<Category> Category { get; set; } = new List<Category>();
        public List<Book> BooksInCategory { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Category = await _context.Category
                .Include(c => c.BookCategories)
                .ThenInclude(bc => bc.Book)
                .ThenInclude(b => b.Author)
                .AsNoTracking()
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category selectedCategory = Category
                    .Where(c => c.ID == id.Value)
                    .SingleOrDefault();

                if (selectedCategory != null)
                {
                    BooksInCategory = selectedCategory.BookCategories
                        .Select(bc => bc.Book)
                        .ToList();
                }
            }
        }
    }
}