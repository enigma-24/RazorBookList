using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorBookList.Data;
using RazorBookList.Model;

namespace RazorBookList.Pages.BookList{
    public class UpsertModel:PageModel{
        private readonly BookListDbContext context;

        public UpsertModel(BookListDbContext _context) => context = _context;

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();
            if(id == null){
                //add new book
                return Page();
            }
            // update existing book
            // Book = await context.Book.FirstOrDefaultAsync(b => b.BookID == id); this is same as next line
            Book = await context.Book.FindAsync(id);
            if(Book == null){
                return NotFound();
            }
            return Page();
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if(Book.BookID == 0){

                    context.Book.Add(Book);
                }else{
                    context.Book.Update(Book);
                }
                await context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}