using AutoMapper;
using BookStore.API.BookOperations.CreateBook;
using BookStore.API.BookOperations.DeleteBook;
using BookStore.API.BookOperations.GetBook;
using BookStore.API.BookOperations.GetBooks;
using BookStore.API.BookOperations.UpdateBook;
using BookStore.API.DBOperations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery getBooksQuery = new GetBooksQuery(_context);
            var result = getBooksQuery.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                GetByIdBookQuery getByIdBook = new GetByIdBookQuery(_context);
                var result = getByIdBook.Handle(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            try
            {
                CreateBookCommand createBookCommand = new CreateBookCommand(_context);
                CreateBookCommandValidator validation = new CreateBookCommandValidator();

                validation.ValidateAndThrow(newBook);                
                createBookCommand.Handle(newBook, _mapper);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            try
            {
                UpdateBookCommand updateBookCommand = new UpdateBookCommand(_context);
                UpdateBookCommandValidator validation = new UpdateBookCommandValidator();
                validation.ValidateAndThrow(updatedBook);
                updateBookCommand.Handle(id, updatedBook);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);
                deleteBookCommand.Handle(id);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }


            return Ok();
        }
    }
}
