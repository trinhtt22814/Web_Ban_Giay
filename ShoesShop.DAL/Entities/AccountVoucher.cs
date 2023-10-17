using ShoesShop.DAL.Entities.Base;

namespace ShoesShop.DAL.Entities
{
    public class AccountVoucher : BaseID
    {
        public Guid IDUser { get; set; }
        public Guid IDVoucher { get; set; }
        public bool IsDeleted { get; set; }
        public virtual User User { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}