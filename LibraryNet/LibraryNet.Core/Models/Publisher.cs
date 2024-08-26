namespace LibraryNet.Core.Models
{
    public class Publisher
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
