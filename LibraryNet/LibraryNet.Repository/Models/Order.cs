using LibraryNet.Repository.Models.VO;

namespace LibraryNet.Repository.Models
{
    public class Order
    {
        public string Id { get; set; }
        public IEnumerable<BookOrderVO> Books { get; set; }
        public decimal Total { get; set; }
        public bool HaveCoupon => Coupon != null;
        public string Coupon { get; set; }
        public string ClientName { get; set; }
        public string DocumentNumber { get; set; }
        public string Date { get; set; }
        public string PaymentMethod { get; set; }
        public string OrderStatus { get; set; }
    }
}
