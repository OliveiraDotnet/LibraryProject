namespace LibraryNet.Repository.Models
{
    public class Coupon
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal DiscountValue { get; set; }
        public int Type { get; set; }
    }
}
