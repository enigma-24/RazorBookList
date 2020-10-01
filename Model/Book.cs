using System;
using System.ComponentModel.DataAnnotations;

namespace RazorBookList.Model
{
    public class Book
    {
        public int BookID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Author { get; set; }
        public string ISBN { get; set; }
    }
}