using LibraryNet.Repository.Interfaces;

namespace LibraryNet.Repository.Models
{
    public class Book : IRecordElement
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Edition { get; set; }
        public string AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public string ReleaseYear { get; set; }
        public decimal Price { get; set; }
        public short Category { get; set; }
        public string PublishCompanyId { get; set; }
        public virtual PublishCompany PublishCompany { get; set; }
        public int NumberPages { get; set; }
        public string Review { get; set; }
        public string Description { get; set; }
        public string Translations { get; set; }
    }
}
