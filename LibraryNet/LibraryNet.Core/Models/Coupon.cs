using LibraryNet.Core.Enums;

namespace LibraryNet.Core.Models
{
    public class Coupon
    {
        public Coupon(string id, string name, decimal discountValue, DiscountType type)
        {
            Id = id;
            Name = name;
            DiscountValue = discountValue;
            Type = type;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal DiscountValue { get; set; }
        public DiscountType Type { get; set; }
    }
}
