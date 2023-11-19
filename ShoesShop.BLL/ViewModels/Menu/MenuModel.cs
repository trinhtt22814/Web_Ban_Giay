 
using ShoesShop.BLL.ViewModels.Brands;
using ShoesShop.BLL.ViewModels.Categories;
using ShoesShop.BLL.ViewModels.Color;
using ShoesShop.BLL.ViewModels.Material;
using ShoesShop.BLL.ViewModels.Size;

namespace ShoesShop.BLL.ViewModels.Menu;

public class MenuModel
{
    public List<BrandDetailModel> Brands { get; set; }
    public List<CategoryDetailModel> Categories { get; set; }
    public List<ColorDetailModel> Colors { get; set; }
    public List<SizeDetailModel> Sizes { get; set; }
    public List<MaterialDetailModel> Materials { get; set; }
    public bool IsShowButtonAdmin { get; set; }
}