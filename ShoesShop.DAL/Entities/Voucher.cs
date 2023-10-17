using ShoesShop.DAL.Entities.Base;

namespace ShoesShop.DAL.Entities
{
    public class Voucher : BaseID
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int Quantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<AccountVoucher> AccountVouchers { get; set; }
        public virtual ICollection<VoucherDetail> VoucherDetail { get; set; }
    }
}