using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorBookList.Data;

namespace RazorBookList.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly BookListDbContext context;

        public BookController(BookListDbContext _context) => context = _context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await context.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id){
            var bookToDelete = await context.Book.FirstOrDefaultAsync(b => b.BookID == id);
            if(bookToDelete != null){
                context.Book.Remove(bookToDelete);
                await context.SaveChangesAsync();
                return Json(new {success = true,message="Book Deleted!"});
            }else{
                return Json(new {success = false, message="Error while deleting Book!"});
            }
        }
    }
}