using ShoesShop.BLL.Common.ViewModel;

namespace ShoesShop.BLL.ViewModels.Voucher
{
    public class VoucherViewModel : BaseIDViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int Quantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}