using AutoMapper;
using BookStore.API.DBOperations;

namespace BookStore.API.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        private readonly BookStoreDbContext _context;

        public CreateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(CreateBookModel model, IMapper mapper)
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == model.Title);

            if (book is not null)
                throw new InvalidOperationException("Kitap zaten mevcut");

            var newBook = mapper.Map<Book>(model);

            //book.Title = model.Title;
            //book.PublishDate = model.PublishDate;
            //book.GenreId = model.GenreId;
            //book.PageCount = model.PageCount;

            _context.Books.Add(newBook);
            _context.SaveChanges();
        }
    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
