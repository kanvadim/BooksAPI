using BooksAPI.Db.Entities;

namespace BooksAPI
{
    public partial class AuthorsBook
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }

        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
