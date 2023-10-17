using ShoesShop.BLL.Common.ViewModel;

namespace ShoesShop.BLL.ViewModels.ProductDetail
{
    public class UpdateProductDetailViewModel : BaseIDViewModel
    {
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string DefaultImage { get; set; }
    }
}