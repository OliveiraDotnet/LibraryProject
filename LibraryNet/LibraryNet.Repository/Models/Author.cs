using LibraryNet.Repository.Interfaces;

namespace LibraryNet.Repository.Models
{
    public class Author :IRecordElement
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Book> Books { get; set; }
    }
}
