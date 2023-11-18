 
using ShoesShop.BLL.ViewModels.Brands;
using ShoesShop.BLL.ViewModels.Categories;

namespace ShoesShop.BLL.ViewModels.Product;

public class ProductFilterModel
{
    public List<CategoryDetailModel> Categories { get; set; }
    public List<BrandDetailModel> Brands { get; set; }
    public ProductDetailModel Product { get; set; }
}