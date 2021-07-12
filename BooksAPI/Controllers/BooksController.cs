using BooksAPI.Db;
using BooksAPI.Db.Entities;
using BooksAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BooksContext _context;

        public BooksController(BooksContext context)
        {
            _context = context;
        }

        [HttpGet("{AuthorName}")]
        public async Task<int> Get(string AuthorName)
        {
            var bookCount = (from a in _context.Authors
                             join ab in _context.AuthorsBooks on a.Id equals ab.AuthorId
                             join b in _context.Books on ab.BookId equals b.Id
                             where a.Name == AuthorName
                             select b).Count();
            return bookCount;
        }

        [HttpPost("Add")]
        public async Task Post(NewBook newBook)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.BookName == newBook.BookName);
            if(book == null)
            {
                book = new Book() { BookName = newBook.BookName };
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
            }

            Author author;
            AuthorsBook authorsBook;
            foreach (string name in newBook.AuthorName)
            {
                author = await _context.Authors.FirstOrDefaultAsync(a => a.Name == name);
                if(author == null)
                {
                    author = new Author() { Name = name };
                    await _context.Authors.AddAsync(author);
                    await _context.SaveChangesAsync();
                }

                authorsBook = new AuthorsBook() { AuthorId = author.Id, BookId = book.Id };
                await _context.AddAsync(authorsBook);
            }

            await _context.SaveChangesAsync();
        }

        [HttpPut("UpdateAuthor")]
        public async Task PutAuthor(string authorName, string newAuthorName)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Name == authorName);
            if(author != null)
            {
                author.Name = newAuthorName;
                await _context.SaveChangesAsync();
            }
        }

        [HttpPut("UpdateBook")]
        public async Task PutBook(string bookName, string newBookName)
        {
            var book = await _context.Books.FirstOrDefaultAsync(a => a.BookName == bookName);
            if (book != null) 
            {
                book.BookName = newBookName;
                await _context.SaveChangesAsync();
            }
        }

        [HttpDelete("DeleteAuthor")]
        public async Task DeleteAuthor(string name)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Name == name);
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        [HttpDelete("DeleteBook")]
        public async Task DeleteBook(string name)
        {
            var author = await _context.Books.FirstOrDefaultAsync(a => a.BookName == name);
            _context.Books.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}
