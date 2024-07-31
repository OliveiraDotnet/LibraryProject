using LibraryNet.Core.Enums;

namespace LibraryNet.Core.Models
{
    public class Book
    {
        public Book(string id, string name, string edition, Author author, string releaseYear, decimal price, LiteraryGenre category, PublishCompany publishCompany, int numberPages, string review, string description, IEnumerable<Language> translations)
        {
            Id = id;
            Name = name;
            Edition = edition;
            Author = author;
            ReleaseYear = releaseYear;
            Price = price;
            Category = category;
            PublishCompany = publishCompany;
            NumberPages = numberPages;
            Review = review;
            Description = description;
            Translations = translations;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Edition { get; set; }
        public Author Author { get; set; }
        public string ReleaseYear { get; set; }
        public decimal Price { get; set; }
        public LiteraryGenre Category { get; set; }
        public PublishCompany PublishCompany { get; set; }
        public int NumberPages { get; set; }
        public string Review { get; set; }
        public string Description { get; set; }
        public IEnumerable<Language> Translations { get; set; }
    }
}
