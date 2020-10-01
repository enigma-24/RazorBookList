using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> OnPostDelete(int id){
            var bookToDelete = await context.Book.FindAsync(id);
            if(bookToDelete != null){
                context.Book.Remove(bookToDelete);
                await context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return NotFound();
        }
    }
}