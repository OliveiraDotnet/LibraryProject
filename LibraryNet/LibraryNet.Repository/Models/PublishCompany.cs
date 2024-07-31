using LibraryNet.Repository.Interfaces;

namespace LibraryNet.Repository.Models
{
    public class PublishCompany : IRecordElement
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public virtual IEnumerable<Book> Books { get; set; }
    }
}
