 
 
using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Common.ViewModels;
using ShoesShop.BLL.Persistence;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Categories;
using ShoesShop.DAL.Entities;
using ShoesShop.DAL.Helpers;

namespace ShoesShop.BLL.Services.Implements;

public class CategoryService : ICategoryService
{
    private readonly WebDbContext _dbContext;

    public CategoryService(WebDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CategoryDetailModel>> GetListCategory()
    {
        var data = await _dbContext.Categories
            .Where(s => !s.IsDeleted)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();

        return data.Adapt<List<CategoryDetailModel>>();
    }

    public async Task<CategoryDetailModel> GetDetail(string id)
    {
        var data = await _dbContext.Categories
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == Guid.Parse(id));

        return data == null ? new CategoryDetailModel() : data.Adapt<CategoryDetailModel>();
    }

    public async Task<bool> Delete(DeleteModel model)
    {
        var data = await _dbContext.Categories
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

        if (data == null)
        {
            return false;
        }

        data.IsDeleted = true;

        _dbContext.Categories.Update(data);
        await _dbContext.SaveChangesAsync(new CancellationToken());

        return true;
    }

    public async Task<bool> AddNew(AddNewCategoryModel model)
    {
        var data = await _dbContext.Categories
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

        if (data != null)
        {
            return false;
        }

        var newData = model.Adapt<Category>();
        newData.Code = model.Name.VietnameseToNormalString();

        await _dbContext.Categories.AddAsync(newData);

        await _dbContext.SaveChangesAsync(new CancellationToken());

        return true;
    }

    public async Task<bool> Update(UpdateCategoryModel model)
    {
        var data = await _dbContext.Categories
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

        if (data == null)
        {
            return false;
        }

        data.Name = model.Name;
        data.Code = model.Name.VietnameseToNormalString();

        _dbContext.Categories.Update(data);

        await _dbContext.SaveChangesAsync(new CancellationToken());

        return true;
    }
}