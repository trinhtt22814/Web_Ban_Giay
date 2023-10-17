using ShoesShop.BLL.Common.ViewModel;

namespace ShoesShop.BLL.ViewModels.ProductDetail
{
    public class AddProductDetailViewModel : BaseIDViewModel
    {
        public Guid IDCategory { get; set; }
        public Guid IDSize { get; set; }
        public Guid IDProduct { get; set; }
        public Guid IDMaterial { get; set; }
        public Guid IDBrand { get; set; }
        public Guid IDColor { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
    }
}