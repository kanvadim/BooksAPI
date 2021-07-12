using System.Collections.Generic;

namespace BooksAPI.Db.Entities
{
    public class Book
    {
        public Book()
        {
            AuthorsBooks = new HashSet<AuthorsBook>();
        }

        public int Id { get; set; }
        public string BookName { get; set; }

        public ICollection<AuthorsBook> AuthorsBooks { get; set; }
    }
}
