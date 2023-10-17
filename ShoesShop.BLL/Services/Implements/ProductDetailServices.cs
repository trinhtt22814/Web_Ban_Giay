using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.ProductDetail;
using ShoesShop.DAL.ApplicationDbContext;

namespace ShoesShop.BLL.Services.Implements
{
    public class ProductDetailServices : IProductDetailServices
    {
        private WebDbContext _dbContext;

        public ProductDetailServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddProductDetail(AddProductDetailViewModel model)
        {
            try
            {
                var data = await _dbContext.ProductDetails.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == model.ID);
                if (data != null)
                {
                    return false;
                }
                await _dbContext.ProductDetails.AddAsync(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProductDetail(Guid id)
        {
            try
            {
                var data = await _dbContext.ProductDetails.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == id);
                if (data != null)
                {
                    return false;
                }
                data.Status = 0;
                _dbContext.ProductDetails.Update(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ProductDetailViewModel>> GetAllProductDetail()
        {
            var data = await _dbContext.ProductDetails.Where(s => s.Status > 0).OrderByDescending(a => a.CreatedDate).ToListAsync();
            return data.Adapt<List<ProductDetailViewModel>>();
        }

        public async Task<ProductDetailViewModel> GetProductDetailById(Guid id)
        {
            var data = await _dbContext.ProductDetails.FirstOrDefaultAsync(x => x.ID == id);
            return data == null ? new ProductDetailViewModel() : data.Adapt<ProductDetailViewModel>();
        }

        public async Task<bool> UpdateProductDetail(UpdateProductDetailViewModel model)
        {
            var data = _dbContext.ProductDetails.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                return false;
            }

            data.Quantity = model.Quantity;
            data.Price = model.Price;
            data.Description = model.Description;
            data.Gender = model.Gender;
            data.DefaultImage = model.DefaultImage;
            data.UpdatedBy = model.UpdatedBy;
            data.LastModifiedDate = DateTime.Now;
            data.Status = model.Status;
            _dbContext.ProductDetails.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return true;
        }
    }
}