using ShoesShop.BLL.Common.ViewModel;

namespace ShoesShop.BLL.ViewModels.VoucherDetail
{
    public class AddVoucherDetailViewModel : BaseIDViewModel
    {
        public Guid IDOrder { get; set; }
        public Guid IDVoucher { get; set; }
        public int BeforePrice { get; set; }
        public int AfterPrice { get; set; }
        public int DiscountPrice { get; set; }
    }
}