using System.Collections.Generic;

namespace BooksAPI.Models
{
    public class NewBook
    {
        public string BookName { get; set; }
        public List<string> AuthorName { get; set; }
    }
}
