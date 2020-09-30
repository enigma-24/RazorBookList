using Microsoft.EntityFrameworkCore;
using RazorBookList.Model;

namespace RazorBookList.Data
{
    public class BookListDbContext:DbContext
    {
        public BookListDbContext(DbContextOptions<BookListDbContext> options):base(options){}

        public DbSet<Book> Book { get; set; }
    }
}
