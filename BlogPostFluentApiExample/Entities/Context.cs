using Microsoft.EntityFrameworkCore;

namespace BlogPostFluentApiExample.Entities
{
    public interface IContext
    {
        DbSet<Author> Authors { get; set; }

        DbSet<Book> Books { get; set; }

        Task<int> SaveChangesAsync();
    }

    public class Context : DbContext, IContext
    {
        public Context() : base()
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=LibraryManagementFluent;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent EF Core Configurations.
            modelBuilder.Entity<Author>()
                .HasMany(x => x.Books)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Cascade); // this will delete the child records if deleted parent record.
        }

        public async Task<int> SaveChangesAsync()
        {
           return await base.SaveChangesAsync();
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
