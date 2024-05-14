using BlogPostFluentApiExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogPostFluentApiExample.DAL
{
    public interface IBookDAL
    {
        Task<List<Book>> GetBooksRepository();

        Task<Book> GetBookByIdRepository(int bookId);

        Task<Book> AddBookRepository(Book book);

        Task<Book> DeleteBookRepository(int bookId);
    }


    public class BookDAL : IBookDAL
    {

        private readonly IContext _context;

        public BookDAL(IContext context)
        {
                _context = context;
        }



        public Task<Book> AddBookRepository(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<Book> DeleteBookRepository(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookByIdRepository(int bookId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Book>> GetBooksRepository()
        {
            return await _context.Books.ToListAsync(); 
        }
    }

}
