using ShoesShop.BLL.Common.ViewModel;

namespace ShoesShop.BLL.ViewModels.Image
{
    public class ImageViewModel : BaseIDViewModel
    {
        public Guid IDProductDetail { get; set; }
        public string Name { get; set; }
    }
}