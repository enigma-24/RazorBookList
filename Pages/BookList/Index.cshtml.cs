using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorBookList.Data;
using RazorBookList.Model;

namespace RazorBookList.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly BookListDbContext context;

        // Expression body syntax for constructor
        public IndexModel(BookListDbContext _context) => context = _context;

        public IEnumerable<Book> Books { get; set; }
        public async Task OnGet()
        {
            Books = await context.Book.ToListAsync();
        }
    }
}