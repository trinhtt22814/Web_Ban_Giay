using ShoesShop.DAL.Entities.Base;

namespace ShoesShop.DAL.Entities
{
    public class Order : BaseID
    {
        public Guid IDUser { get; set; }
        public Guid IDVoucherDatail { get; set; }
        public string PhoneNumber { get; set; }
        public string DeliveryAddress { get; set; }
        public string Username { get; set; }
        public string ItemDiscount { get; set; }
        public int TotalMoney { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public int Price { get; set; }
        public virtual User User { get; set; }
        public virtual IQueryable<OrderDetail> OrderDetail { get; set; }
        public virtual IQueryable<OrderHistory> OrderHistory { get; set; }
        public virtual IQueryable<PaymentMethod> PaymentMethod { get; set; }
        public virtual IQueryable<VoucherDetail> VoucherDetail { get; set; }
    }
}