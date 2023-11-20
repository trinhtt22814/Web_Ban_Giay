using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Common.ViewModels;
using ShoesShop.BLL.Persistence;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Color;
using ShoesShop.DAL.Entities;
using ShoesShop.DAL.Helpers;

namespace ShoesShop.BLL.Services.Implements
{
    public class ColorServices : IColorService
    {
        private WebDbContext _dbContext;

        public ColorServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ColorDetailModel>> GetListColor()
        {
            var data = await _dbContext.Colors
           .Where(s => !s.IsDeleted)
           .OrderByDescending(a => a.CreatedAt)
           .ToListAsync();

            return data.Adapt<List<ColorDetailModel>>();
        }

        public async Task<ColorDetailModel> GetDetail(string id)
        {
            var data = await _dbContext.Colors
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == Guid.Parse(id));

            return data == null ? new ColorDetailModel() : data.Adapt<ColorDetailModel>();
        }

        public async Task<bool> Delete(DeleteModel model)
        {
            var data = await _dbContext.Colors
             .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

            if (data == null)
            {
                return false;
            }

            data.IsDeleted = true;

            _dbContext.Colors.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());

            return true;
        }

        public async Task<bool> AddNew(AddNewColorModel model)
        {
            var data = await _dbContext.Colors
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

            if (data != null)
            {
                return false;
            }

            var newData = model.Adapt<Color>();
            newData.Code = model.Name.VietnameseToNormalString();

            await _dbContext.Colors.AddAsync(newData);

            await _dbContext.SaveChangesAsync(new CancellationToken());

            return true;
        }

        public async Task<bool> Update(UpdateColorModel model)
        {
            var data = await _dbContext.Colors
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

            if (data == null)
            {
                return false;
            }

            data.Name = model.Name;
            data.Code = model.Name.VietnameseToNormalString();

            _dbContext.Colors.Update(data);

            await _dbContext.SaveChangesAsync(new CancellationToken());

            return true;
        }
    }
}