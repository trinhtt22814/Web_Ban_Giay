using BLL.Services.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Common.ViewModels;
using ShoesShop.BLL.Persistence;
using ShoesShop.BLL.ViewModels.Promotion;
using ShoesShop.DAL.Entities;

namespace ShoesShop.BLL.Services.Implements;

public class PromotionService : IPromotionService
{
    private readonly WebDbContext _dbContext;

    public PromotionService(WebDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<PromotionDetailModel>> GetListPromotion()
    {
        var data = await _dbContext.Promotions
            .Where(s => !s.IsDeleted)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();

        return data.Adapt<List<PromotionDetailModel>>();
    }

    public async Task<PromotionDetailModel> GetDetail(string id)
    {
        var data = await _dbContext.Promotions
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == Guid.Parse(id));

        return data == null ? new PromotionDetailModel() : data.Adapt<PromotionDetailModel>();
    }

    public async Task<PromotionDetailModel> GetDetailByCode(string code)
    {
        var data = await _dbContext.Promotions
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Code == code);

        return data == null ? new PromotionDetailModel() : data.Adapt<PromotionDetailModel>();
    }

    public async Task<bool> Delete(DeleteModel model)
    {
        var data = await _dbContext.Promotions
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

        if (data == null)
        {
            return false;
        }

        data.IsDeleted = true;

        _dbContext.Promotions.Update(data);
        await _dbContext.SaveChangesAsync(new CancellationToken());

        return true;
    }

    public async Task<bool> AddNew(AddNewPromotionModel model)
    {
        var data = await _dbContext.Promotions
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

        if (data != null)
        {
            return false;
        }

        var newData = model.Adapt<Promotion>();
        newData.Code = Guid.NewGuid().ToString().Split("-")[1].ToUpper() +
                       Guid.NewGuid().ToString().Split("-")[2].ToUpper();

        await _dbContext.Promotions.AddAsync(newData);

        await _dbContext.SaveChangesAsync(new CancellationToken());

        return true;
    }

    public async Task<bool> Update(UpdatePromotionModel model)
    {
        var data = await _dbContext.Promotions
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

        if (data == null)
        {
            return false;
        }

        data.DiscountPercent = model.DiscountPercent;

        _dbContext.Promotions.Update(data);

        await _dbContext.SaveChangesAsync(new CancellationToken());

        return true;
    }
}