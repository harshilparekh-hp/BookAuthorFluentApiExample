
using BlogPostFluentApiExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogPostFluentApiExample.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        // Generic Repository would implement IGenericRepository interface by implementing all the common features.
        // common functionalities will be used across all the modules during the application development.

        // Generic Repository would need Context and Generic Entities to permanently save changes from and to database.

        private Context context;

        private DbSet<T> entity;

        // paramter-less constructor of GenericRepository to create object of context and entity.
        public GenericRepository()
        {
            context = new Context();
            entity = context.Set<T>();
        }

        public async Task Add(T obj)
        {
            await entity.AddAsync(obj);
        }

        public async Task Delete(object id)
        {
            T existingObject = await entity.FindAsync(id);
            if (existingObject != null)
            {
                entity.Remove(existingObject);
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await entity.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await entity.FindAsync(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task Update(T obj)
        {
            entity.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }

      
    }
}
