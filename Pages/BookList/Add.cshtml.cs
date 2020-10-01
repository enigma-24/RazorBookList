using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorBookList.Data;
using RazorBookList.Model;

namespace RazorBookList.Pages.BookList
{
    public class AddModel:PageModel{
        private readonly BookListDbContext context;

        public AddModel(BookListDbContext _context) => context = _context;

        [BindProperty]
        public Book Book { get; set; } 

        public void OnGet(){
            
        }    

        public async Task<IActionResult> OnPost(){
            if(ModelState.IsValid){
                await context.Book.AddAsync(Book);
                await context.SaveChangesAsync();
                return RedirectToPage(nameof(Index));
            }
            return RedirectToPage();
        }

    }
}