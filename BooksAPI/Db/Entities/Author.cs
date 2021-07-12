using System.Collections.Generic;

namespace BooksAPI.Db.Entities
{
    public class Author
    {
        public Author()
        {
            AuthorsBooks = new HashSet<AuthorsBook>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AuthorsBook> AuthorsBooks { get; set; }
    }
}
