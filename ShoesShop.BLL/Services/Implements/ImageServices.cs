using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Image;
using ShoesShop.DAL.ApplicationDbContext;

namespace ShoesShop.BLL.Services.Implements
{
    public class ImageServices : IImageServices
    {
        private WebDbContext _dbContext;

        public ImageServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddImage(AddImageViewModel model)
        {
            try
            {
                var data = await _dbContext.Images.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == model.ID);
                if (data != null)
                {
                    return false;
                }
                await _dbContext.Images.AddAsync(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteImage(Guid id)
        {
            try
            {
                var data = await _dbContext.Images.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == id);
                if (data != null)
                {
                    return false;
                }
                data.Status = 0;
                _dbContext.Images.Update(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ImageViewModel>> GetImageByProduct(Guid idProduct)
        {
            var data = await _dbContext.Images.Where(s => s.Status > 0 && s.IDProductDetail == idProduct).OrderByDescending(a => a.CreatedDate).ToListAsync();
            return data.Adapt<List<ImageViewModel>>();
        }

        public async Task<bool> UpdateImage(UpdateImageViewModel model)
        {
            var data = _dbContext.Images.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                return false;
            }
            data.Name = model.Name;
            data.UpdatedBy = model.UpdatedBy;
            data.LastModifiedDate = DateTime.Now;
            data.Status = model.Status;
            _dbContext.Images.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return true;
        }
    }
}