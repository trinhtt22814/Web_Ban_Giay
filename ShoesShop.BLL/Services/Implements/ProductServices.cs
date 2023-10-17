using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Product;
using ShoesShop.DAL.ApplicationDbContext;

namespace ShoesShop.BLL.Services.Implements
{
    public class ProductServices : IProductServices
    {
        private WebDbContext _dbContext;

        public ProductServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddProduct(AddProductViewModel model)
        {
            try
            {
                var data = await _dbContext.Products.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == model.ID);
                if (data != null)
                {
                    return false;
                }
                await _dbContext.Products.AddAsync(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            try
            {
                var data = await _dbContext.Products.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == id);
                if (data != null)
                {
                    return false;
                }
                data.Status = 0;
                _dbContext.Products.Update(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ProductViewModel>> GetAllProduct()
        {
            var data = await _dbContext.Products.Where(s => s.Status > 0).OrderByDescending(a => a.CreatedDate).ToListAsync();
            return data.Adapt<List<ProductViewModel>>();
        }

        public async Task<ProductViewModel> GetProductById(Guid id)
        {
            var data = await _dbContext.Products.FirstOrDefaultAsync(x => x.ID == id);
            return data == null ? new ProductViewModel() : data.Adapt<ProductViewModel>();
        }

        public async Task<bool> UpdateProduct(UpdateProductViewModel model)
        {
            var data = _dbContext.Products.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                return false;
            }
            data.Name = model.Name;
            data.UpdatedBy = model.UpdatedBy;
            data.LastModifiedDate = DateTime.Now;
            data.Status = model.Status;
            _dbContext.Products.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return true;
        }
    }
}