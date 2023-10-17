using ShoesShop.BLL.Common.ViewModel;

namespace ShoesShop.BLL.ViewModels.PaymentMethod
{
    public class PaymentMethodViewModel : BaseIDViewModel
    {
        public Guid IDOrder { get; set; }
        public string Method { get; set; }
        public string Description { get; set; }
    }
}