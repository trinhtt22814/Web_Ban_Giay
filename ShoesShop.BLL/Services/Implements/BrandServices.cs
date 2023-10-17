using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Brand;
using ShoesShop.DAL.ApplicationDbContext;

namespace ShoesShop.BLL.Services.Implements
{
    public class BrandServices : IBrandServices
    {
        private WebDbContext _dbContext;

        public BrandServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddBrand(AddBrandViewModel model)
        {
            try
            {
                var data = await _dbContext.Brands.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == model.ID);
                if (data != null)
                {
                    return false;
                }
                await _dbContext.Brands.AddAsync(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteBrand(Guid id)
        {
            try
            {
                var data = await _dbContext.Brands.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == id);
                if (data != null)
                {
                    return false;
                }
                data.Status = 0;
                _dbContext.Brands.Update(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<BrandViewModel> GetBrandById(Guid id)
        {
            var data = await _dbContext.Brands.FirstOrDefaultAsync(x => x.ID == id);
            return data == null ? new BrandViewModel() : data.Adapt<BrandViewModel>();
        }

        public async Task<List<BrandViewModel>> GetAllBrand()
        {
            var data = await _dbContext.Brands.Where(s => s.Status > 0).OrderByDescending(a => a.CreatedDate).ToListAsync();
            return data.Adapt<List<BrandViewModel>>();
        }

        public async Task<bool> UpdateBrand(UpdateBrandViewModel model)
        {
            var data = _dbContext.Brands.Find(model.ID);
            if (data == null)
            {
                return false;
            }
            data.Name = model.Name;
            data.UpdatedBy = model.UpdatedBy;
            data.LastModifiedDate = DateTime.Now;
            data.Status = model.Status;
            _dbContext.Brands.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return true;
        }
    }
}