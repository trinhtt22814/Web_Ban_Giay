 
using ShoesShop.BLL.ViewModels.Brands;
using ShoesShop.BLL.ViewModels.Categories;

namespace ShoesShop.BLL.ViewModels.Menu;

public class MenuModel
{
    public List<BrandDetailModel> Brands { get; set; }
    public List<CategoryDetailModel> Categories { get; set; }
    public bool IsShowButtonAdmin { get; set; }
}