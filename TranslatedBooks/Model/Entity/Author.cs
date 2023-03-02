namespace TranslatedBooks.Model.Entity
{
    public class Author
    {
        public int Id { get; set; }
        public string? Birthday { get; set; }
        public int[]? BooksIds { get; set; }
        public string? Country { get; set; }
        public string? FullName { get; set; }
    }
}
