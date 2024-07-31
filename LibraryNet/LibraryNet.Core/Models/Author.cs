namespace LibraryNet.Core.Models
{
    public class Author
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
