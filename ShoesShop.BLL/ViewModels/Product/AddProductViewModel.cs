using ShoesShop.BLL.Common.ViewModel;

namespace ShoesShop.BLL.ViewModels.Product
{
    public class AddProductViewModel : BaseIDViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}