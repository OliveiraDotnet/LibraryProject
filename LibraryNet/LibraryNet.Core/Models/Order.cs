using LibraryNet.Core.Enums;

namespace LibraryNet.Core.Models
{
    public class Order
    {
        public Order(string id, ShoppingCart cart, Coupon coupon, string clientName, DateTime date, PaymentMethod paymentMethod, OrderStatus orderStatus)
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
        }

        public string Id { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public decimal Total { get; set; }
        public bool HaveCoupon => Coupon != null;
        public Coupon Coupon { get; set; }
        public string ClientName { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime Date { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public void CalculateTotalOrderWithCoupon()
        {
            Total -= Coupon.Type switch
            {
                DiscountType.Percentage => (Coupon.DiscountValue / 100 * Total),
                _ => Coupon.DiscountValue,
            };
        }
    }
}
