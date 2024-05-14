namespace BlogPostFluentApiExample.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        // Get All
        Task<IEnumerable<T>> GetAll();

        // Get By Id
        Task<T> GetById(object id);

        // Add
        Task Add(T obj);

        // Update
        Task Update(T obj);

        // Delete
        Task Delete(object id);

        // Save Changes
        void Save();

    }
}
