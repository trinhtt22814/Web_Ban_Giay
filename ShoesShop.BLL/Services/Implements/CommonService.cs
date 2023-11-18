using BLL.Services.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Persistence;
using ShoesShop.BLL.ViewModels.Menu;
using ShoesShop.BLL.ViewModels.Status;

namespace ShoesShop.BLL.Services.Implements;

public class CommonService : ICommonService
{
    private readonly IBrandService _brandService;
    private readonly ICategoryService _categoryService;
    private readonly WebDbContext _dbContext;

    public CommonService(IBrandService brandService
        , ICategoryService categoryService
        , WebDbContext dbContext)
    {
        _brandService = brandService;
        _categoryService = categoryService;
        _dbContext = dbContext;
    }

    public async Task<MenuModel> GetMenu(bool isAdmin)
    {
        var categories = await _categoryService.GetListCategory();
        var brands = await _brandService.GetListBrand();

        var menu = new MenuModel()
        {
            Brands = brands,
            Categories = categories,
            IsShowButtonAdmin = isAdmin
        };

        return menu;
    }

    public async Task<List<StatusDetailModel>> GetDropdownStatus(string type)
    {
        var status = await _dbContext.Status.Where(s => !s.IsDeleted && s.Type == type).ToListAsync();

        return status.Adapt<List<StatusDetailModel>>();
    }
}