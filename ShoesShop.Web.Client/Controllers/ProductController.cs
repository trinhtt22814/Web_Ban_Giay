using ShoesShop.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Product;
using ShoesShop.BLL.ViewModels.Search;
using ShoesShop.DAL.Helpers;

namespace ShoesShop.Web.Client.Controllers;

public class ProductController : BaseController
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IBrandService _brandService;
    private readonly IColorService _colorService;
    private readonly ISizeService _sizeService;
    private readonly IMaterialService _materialService;

    public ProductController(IProductService productService
        , ICategoryService categoryService
        , IBrandService brandService
        , IColorService colorService
        , ISizeService sizeService
        , IMaterialService materialService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _brandService = brandService;
        _colorService = colorService;
        _sizeService = sizeService;
        _materialService = materialService;
    }

    public async Task<IActionResult> Detail(string id)
    {
        var data = await _productService.Detail(id);

        if (string.IsNullOrEmpty(data?.Name))
        {
            return Redirect("/Common/NotFoundPage");
        }

        return View(data);
    }

    [Route("/p/{url}")]
    public async Task<IActionResult> DetailByUrl(string url)
    {
        var data = await _productService.DetailByUrl(url);

        if (string.IsNullOrEmpty(data?.Name))
        {
            return Redirect("/Common/NotFoundPage");
        }

        return View("Detail", data);
    }

    public async Task<IActionResult> Brand(string value = "", int page = 1)
    {
        var model = new SearchPageModel();
        var dataList = await _productService.GetListCategoryOrBrand("brand", value);
        var minPrice = dataList?.Count > 0 ? dataList.Min(r => r.Price) : 0;
        var maxPrice = dataList?.Count > 0 ? dataList.Max(r => r.Price) : 0;
        model.PagingResult = PagingHelper<ProductDetailModel>.ToPaging(dataList, page, 10, value, minPrice, maxPrice);
        model.Categories = await _categoryService.GetListCategory();
        model.Brands = await _brandService.GetListBrand();
        model.Colors = await _colorService.GetListColor();
        model.Sizes = await _sizeService.GetListSize();
        model.Materials = await _materialService.GetListMaterial();

        return View(model);
    }

    public async Task<IActionResult> Category(string value = "", int page = 1)
    {
        var model = new SearchPageModel();
        var dataList = await _productService.GetListCategoryOrBrand("category", value);
        var minPrice = dataList?.Count > 0 ? dataList.Min(r => r.Price) : 0;
        var maxPrice = dataList?.Count > 0 ? dataList.Max(r => r.Price) : 0;
        model.PagingResult = PagingHelper<ProductDetailModel>.ToPaging(dataList, page, 10, value, minPrice, maxPrice);
        model.Categories = await _categoryService.GetListCategory();
        model.Brands = await _brandService.GetListBrand();
        model.Colors = await _colorService.GetListColor();
        model.Sizes = await _sizeService.GetListSize();
        model.Materials = await _materialService.GetListMaterial();

        return View(model);
    }

    public async Task<IActionResult> Search(string searchText, int page = 1)
    {
        var model = new SearchPageModel();
        var dataList = await _productService.GetListSearch(searchText);
        var minPrice = dataList?.Count > 0 ? dataList.Min(r => r.Price) : 0;
        var maxPrice = dataList?.Count > 0 ? dataList.Max(r => r.Price) : 0;
        model.PagingResult =
            PagingHelper<ProductDetailModel>.ToPaging(dataList, page, 10, searchText, minPrice, maxPrice);
        model.Categories = await _categoryService.GetListCategory();
        model.Brands = await _brandService.GetListBrand();
        model.Colors = await _colorService.GetListColor();
        model.Sizes = await _sizeService.GetListSize();
        model.Materials = await _materialService.GetListMaterial();

        return View(model);
    }

    public async Task<IActionResult> SearchRangePrice(decimal? min, decimal? max, int page = 1)
    {
        var model = new SearchPageModel();
        min ??= 0;
        max ??= int.MaxValue;
        var dataListMinMax = await _productService.GetListSearch("");
        var dataList = _productService.GetListRangePrice(dataListMinMax, min, max);
        var minPrice = dataList?.Count > 0 ? dataList.Min(r => r.Price) : 0;
        var maxPrice = dataList?.Count > 0 ? dataList.Max(r => r.Price) : 0;
        model.PagingResult = PagingHelper<ProductDetailModel>.ToPaging(dataList, page, 10, "", minPrice, maxPrice);
        model.Categories = await _categoryService.GetListCategory();
        model.Brands = await _brandService.GetListBrand();
        model.Colors = await _colorService.GetListColor();
        model.Sizes = await _sizeService.GetListSize();
        model.Materials = await _materialService.GetListMaterial();

        return View(model);
    }
}