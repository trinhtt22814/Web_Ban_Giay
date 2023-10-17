using ShoesShop.BLL.Common.ViewModel;

namespace ShoesShop.BLL.ViewModels.VoucherDetail
{
    public class UpdateVoucherDetailViewModel : BaseIDViewModel
    {
        public int AfterPrice { get; set; }
        public int DiscountPrice { get; set; }
    }
}