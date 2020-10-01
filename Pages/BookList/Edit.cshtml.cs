using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorBookList.Data;
using RazorBookList.Model;

namespace RazorBookList.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly BookListDbContext context;

        public EditModel(BookListDbContext _context) => context = _context;

        [BindProperty]
        public Book Book { get; set; }
        
        public async Task OnGet(int id)
        {
            Book = await context.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost(){
            if(ModelState.IsValid){
                var bookToEdit = await context.Book.FindAsync(Book.BookID);
                bookToEdit.Name = Book.Name;
                bookToEdit.Author = Book.Author;
                bookToEdit.ISBN = Book.ISBN;

                await context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}