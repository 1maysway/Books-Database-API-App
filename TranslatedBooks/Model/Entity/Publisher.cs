namespace TranslatedBooks.Model.Entity
{
    public class Publisher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public int[]? BooksIds { get; set; }
    }
}
