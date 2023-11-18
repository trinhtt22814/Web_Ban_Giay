 
using ShoesShop.BLL.ViewModels.Brands;
using ShoesShop.BLL.ViewModels.Categories;
using ShoesShop.BLL.ViewModels.Product;
using ShoesShop.DAL.Helpers;

namespace ShoesShop.BLL.ViewModels.Search;

public class SearchPageModel
{
    public PagingResult<ProductDetailModel> PagingResult { get; set; }
    public List<CategoryDetailModel> Categories { get; set; }
    public List<BrandDetailModel> Brands { get; set; }
}