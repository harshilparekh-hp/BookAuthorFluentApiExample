using BlogPostFluentApiExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogPostFluentApiExample.DAL
{
    public interface IAuthorDAL
    {
        Task<List<Author>> GetAuthorsRepository();

        Task<Author> AddAuthorsRepository(Author author);
    }

    public class AuthorDAL : IAuthorDAL
    {
        private readonly IContext _context;
        public AuthorDAL(IContext context)
        {
            _context = context;
        }

        public async Task<Author> AddAuthorsRepository(Author author)
        {
            try
            {
                await _context.Authors.AddAsync(author);
                await _context.SaveChangesAsync();
                return author;
            }
            catch (DbUpdateException ex)
            {

                throw new Exception("error occured", ex);
            }
           
        }

        public async Task<List<Author>> GetAuthorsRepository()
        {
            return await _context.Authors.ToListAsync();
        }
    }
}
