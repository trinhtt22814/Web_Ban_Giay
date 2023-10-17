using ShoesShop.BLL.Common.ViewModel;

namespace ShoesShop.BLL.ViewModels.OrderHistory
{
    public class OrderHistoryViewModel : BaseIDViewModel
    {
        public Guid IdOrder { get; set; }
        public string ActionDescription { get; set; }
    }
}