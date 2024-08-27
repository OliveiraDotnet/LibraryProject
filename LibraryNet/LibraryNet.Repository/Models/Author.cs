using LibraryNet.Repository.Interfaces;

namespace LibraryNet.Repository.Models
{
    public class Author : IRecordElement
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
