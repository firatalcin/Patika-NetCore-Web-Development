using BookStore.API.DBOperations;

namespace BookStore.API.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _context;

        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);

            if (book is null)
                throw new InvalidOperationException("Kitap Bulunamadı");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
