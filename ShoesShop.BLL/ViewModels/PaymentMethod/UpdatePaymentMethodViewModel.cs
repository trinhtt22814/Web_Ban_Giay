using ShoesShop.BLL.Common.ViewModel;

namespace ShoesShop.BLL.ViewModels.PaymentMethod
{
    public class UpdatePaymentMethodViewModel : BaseIDViewModel
    {
        public string Method { get; set; }
        public string Description { get; set; }
    }
}