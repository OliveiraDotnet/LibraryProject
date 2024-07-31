namespace LibraryNet.Core.Models
{
    public class ShoppingCart
    {
        public decimal SubTotal { get; }
        public ShoppingCart(string id, string document, IEnumerable<Book> books)
        {
            Id = id;
            SubTotal = books.Sum(b => b.Price);
            Document = document;
            Books = books;
        }

        public string Id { get; set; }
        public string Document { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
