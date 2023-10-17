using ShoesShop.DAL.Entities.Base;

namespace ShoesShop.DAL.Entities
{
    public class VoucherDetail : BaseID
    {
        public Guid IDOrder { get; set; }
        public Guid IDVoucher { get; set; }
        public int BeforePrice { get; set; }
        public int AfterPrice { get; set; }
        public int DiscountPrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}