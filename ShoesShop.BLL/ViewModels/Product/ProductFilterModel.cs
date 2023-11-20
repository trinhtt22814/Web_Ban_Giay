using ShoesShop.BLL.ViewModels.Brands;
using ShoesShop.BLL.ViewModels.Categories;
using ShoesShop.BLL.ViewModels.Color;
using ShoesShop.BLL.ViewModels.Material;
using ShoesShop.BLL.ViewModels.Size;

namespace ShoesShop.BLL.ViewModels.Product;

public class ProductFilterModel
{
	public List<CategoryDetailModel> Categories { get; set; }
	public List<BrandDetailModel> Brands { get; set; }
	public List<ColorDetailModel> Colors { get; set; }
	public List<SizeDetailModel> Sizes { get; set; }
	public List<MaterialDetailModel> Materials { get; set; }
	public ProductDetailModel Product { get; set; }
}