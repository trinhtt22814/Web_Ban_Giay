using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Size;
using ShoesShop.DAL.ApplicationDbContext;

namespace ShoesShop.BLL.Services.Implements
{
    public class SizeServices : ISizeServices
    {
        private WebDbContext _dbContext;

        public SizeServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddSize(AddSizeViewModel model)
        {
            try
            {
                var data = await _dbContext.Sizes.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == model.ID);
                if (data != null)
                {
                    return false;
                }
                await _dbContext.Sizes.AddAsync(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSize(Guid id)
        {
            try
            {
                var data = await _dbContext.Sizes.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == id);
                if (data != null)
                {
                    return false;
                }
                data.Status = 0;
                _dbContext.Sizes.Update(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<SizeViewModel>> GetAllSize()
        {
            var data = await _dbContext.Sizes.Where(s => s.Status > 0).OrderByDescending(a => a.CreatedDate).ToListAsync();
            return data.Adapt<List<SizeViewModel>>();
        }

        public async Task<SizeViewModel> GetSizeById(Guid id)
        {
            var data = await _dbContext.Sizes.FirstOrDefaultAsync(x => x.ID == id);
            return data == null ? new SizeViewModel() : data.Adapt<SizeViewModel>();
        }

        public async Task<bool> UpdateSize(UpdateSizeViewModel model)
        {
            var data = _dbContext.Sizes.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                return false;
            }
            data.Name = model.Name;
            data.UpdatedBy = model.UpdatedBy;
            data.LastModifiedDate = DateTime.Now;
            data.Status = model.Status;
            _dbContext.Sizes.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return true;
        }
    }
}