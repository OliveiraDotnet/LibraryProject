using LibraryNet.Repository.Interfaces;
using LibraryNet.Repository.Models.VO;
using MongoDB.Bson.Serialization.Attributes;

namespace LibraryNet.Repository.Models
{
    [BsonIgnoreExtraElements]
    public class Order : IRecordElement
    {
        [BsonId]
        public string Id { get; set; }
        public decimal Total { get; set; }
        public bool HaveCoupon => Coupon != null;
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }
        public string CouponId { get; set; }
        public Coupon Coupon { get; set; }
        public string ClientName { get; set; }
        public string DocumentNumber { get; set; }
        public string PaymentMethod { get; set; }
        public int OrderStatus { get; set; }
        public AdressVO Adress { get; set; }
        public List<BookOrderVO> Books { get; set; }
    }
}
