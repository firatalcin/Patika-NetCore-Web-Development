using BookStore.API.BookOperations.CreateBook;
using BookStore.API.BookOperations.GetBooks;
using BookStore.API.DBOperations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public BooksController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery getBooksQuery = new GetBooksQuery(_context);
            var result = getBooksQuery.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = _context.Books.Where(x => x.Id == id).FirstOrDefault();

            if (book == null)
            {
                return null;
            }
            else
            {
                return book;
            }
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            try
            {
                CreateBookCommand createBookCommand = new CreateBookCommand(_context);
                createBookCommand.Handle(newBook);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);

            if (book is null)
            {
                return NotFound();
            }

            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id) 
        {
            var book = _context.Books.SingleOrDefault( x => x.Id == id);

            if(book is null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
    }
}
