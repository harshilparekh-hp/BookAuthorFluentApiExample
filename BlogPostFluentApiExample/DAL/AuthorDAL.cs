using BlogPostFluentApiExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogPostFluentApiExample.DAL
{
    public interface IAuthorDAL
    {
       
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

        public Task<Author> DeleteAuthorRepository(int authorId)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAuthorByIdRepository(int authorId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Author>> GetAuthorsRepository()
        {
            return await _context.Authors.ToListAsync();
        }
    }
}
