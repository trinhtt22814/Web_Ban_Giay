using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Color;
using ShoesShop.DAL.ApplicationDbContext;

namespace ShoesShop.BLL.Services.Implements
{
    public class ColorServices : IColorServices
    {
        private WebDbContext _dbContext;

        public ColorServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddColor(AddColorViewModel model)
        {
            try
            {
                var data = await _dbContext.Colors.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == model.ID);
                if (data != null)
                {
                    return false;
                }
                await _dbContext.Colors.AddAsync(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteColor(Guid id)
        {
            try
            {
                var data = await _dbContext.Colors.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == id);
                if (data != null)
                {
                    return false;
                }
                data.Status = 0;
                _dbContext.Colors.Update(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ColorViewModel> GetColorById(Guid id)
        {
            var data = await _dbContext.Colors.FirstOrDefaultAsync(x => x.ID == id);
            return data == null ? new ColorViewModel() : data.Adapt<ColorViewModel>();
        }

        public async Task<List<ColorViewModel>> GetAllColor()
        {
            var data = await _dbContext.Colors.Where(s => s.Status > 0).OrderByDescending(a => a.CreatedDate).ToListAsync();
            return data.Adapt<List<ColorViewModel>>();
        }

        public async Task<bool> UpdateColor(UpdateColorViewModel model)
        {
            var data = _dbContext.Colors.Find(model.ID);
            if (data == null)
            {
                return false;
            }
            data.Name = model.Name;
            data.UpdatedBy = model.UpdatedBy;
            data.LastModifiedDate = DateTime.Now;
            data.Status = model.Status;
            _dbContext.Colors.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return true;
        }
    }
}