using BookStore.API.BookOperations.GetBooks;
using BookStore.API.Common;
using BookStore.API.DBOperations;

namespace BookStore.API.BookOperations.GetBook
{
    public class GetByIdBookQuery
    {
        private readonly BookStoreDbContext _context;

        public GetByIdBookQuery(BookStoreDbContext context)
        {
            _context = context;
        }

        public BooksViewModel Handle(int id)
        {
            var result = _context.Books.Where(x => x.Id == id).FirstOrDefault();

            if (result is null)
                throw new InvalidOperationException("Kitap Bulunamadı");

            return new BooksViewModel
            {
                Title = result.Title,
                Genre = ((GenreEnum)result.GenreId).ToString(),
                PageCount = result.PageCount,
                PublishDate = result.PublishDate.ToString("dd/MM/yyyy"),
            };
        }
    }
}
