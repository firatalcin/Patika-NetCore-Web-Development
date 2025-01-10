using BookStore.API.DBOperations;

namespace BookStore.API.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _context;

        public UpdateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(int id, UpdateBookModel model)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);

            if (book is null)
            {
                throw new InvalidOperationException("Kitap Bulanamadı");
            }

            book.Title = model.Title != default ? model.Title : book.Title;
            book.PublishDate = model.PublishDate != default ? model.PublishDate : book.PublishDate;
            book.GenreId = model.GenreId != default ? model.GenreId : book.GenreId;
            book.PageCount = model.PageCount != default ? model.PageCount : book.PageCount;

            _context.SaveChanges();
        }
    }

    public class UpdateBookModel
    {
        public int id;
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
