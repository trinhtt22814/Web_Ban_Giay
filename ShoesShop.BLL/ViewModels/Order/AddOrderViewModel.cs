using ShoesShop.BLL.Common.ViewModel;

namespace ShoesShop.BLL.ViewModels.Order
{
    public class AddOrderViewModel : BaseIDViewModel
    {
        public Guid IDUser { get; set; }
        public string PhoneNumber { get; set; }
        public string DeliveryAddress { get; set; }
        public string Username { get; set; }
        public string ItemDiscount { get; set; }
        public int TotalMoney { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public int Price { get; set; }
    }
}