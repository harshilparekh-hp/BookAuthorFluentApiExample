namespace BlogPostFluentApiExample.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string AuthorEmail { get; set; }

        public string Publication { get; set; }

        public List<Book> Books { get; set; } // Navigation property
    }
}
