namespace TranslatedBooks.Model.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? PagesCount { get; set; }
        public int? PublisherId { get; set; }
        public string? PublishedDate { get; set; }
        public int[]? AuthorsIds { get; set; }
        public int[]? GenresIds { get; set; }
        public string? PublishedCountry { get; set; }
        public string? OriginalTitle { get; set; }


        public override string ToString()
        {
            return $"{Id} - {Description} - {PagesCount} - {PublisherId}";
        }

    }
}