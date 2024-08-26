using LibraryNet.Core.Enums;

namespace LibraryNet.Core.Models
{
    public class Order
    {
        public Order(string id, string clientName, DateTime date, PaymentMethod paymentMethod, OrderStatus orderStatus, ShoppingCart cart, Coupon coupon, Address address)
        {
            Id = id;
            Books = cart.Books;
            Total = cart.SubTotal;
            Coupon = coupon;
            ClientName = clientName;
            DocumentNumber = cart.Document;
            Date = date;
            PaymentMethod = paymentMethod;
            OrderStatus = orderStatus;
            Address = address;
        }

        public string Id { get; set; }
        public string ClientName { get; set; }
        public bool HaveCoupon => Coupon != null;
        public decimal Total { get; set; }
        public string DocumentNumber { get; set; }
        public Coupon? Coupon { get; set; }
        public Address Address { get; set; }
        public DateTime Date { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public IEnumerable<Book> Books { get; set; }

        public void CalculateTotalOrderWithCoupon() => Total -= Coupon.Type switch
        {
            DiscountType.Percentage => (Coupon.DiscountValue / 100 * Total),
            _ => Coupon.DiscountValue,
        };
    }
}
