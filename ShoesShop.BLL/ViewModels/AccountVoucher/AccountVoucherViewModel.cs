using ShoesShop.BLL.Common.ViewModel;

namespace ShoesShop.BLL.ViewModels.AccountVoucher
{
    public class AccountVoucherViewModel : BaseIDViewModel
    {
        public Guid IDUser { get; set; }
        public Guid IDVoucher { get; set; }
        public bool IsDeleted { get; set; }
    }
}