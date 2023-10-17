using ShoesShop.BLL.Common.ViewModel;

namespace ShoesShop.BLL.ViewModels.PaymentMethod
{
    public class AddPaymentMethodViewModel : BaseIDViewModel
    {
        public Guid IDOrder { get; set; }
        public string Method { get; set; }
        public string Description { get; set; }
    }
}