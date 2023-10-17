using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Category;
using ShoesShop.DAL.ApplicationDbContext;

namespace ShoesShop.BLL.Services.Implements
{
    public class CategoryServices : ICategoryServices
    {
        private WebDbContext _dbContext;

        public CategoryServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddCategory(AddCategoryViewModel model)
        {
            try
            {
                var data = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == model.ID);
                if (data != null)
                {
                    return false;
                }
                await _dbContext.Categories.AddAsync(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            try
            {
                var data = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == id);
                if (data != null)
                {
                    return false;
                }
                data.Status = 0;
                _dbContext.Categories.Update(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CategoryViewModel> GetCategoryById(Guid id)
        {
            var data = await _dbContext.Categories.FirstOrDefaultAsync(x => x.ID == id);
            return data == null ? new CategoryViewModel() : data.Adapt<CategoryViewModel>();
        }

        public async Task<List<CategoryViewModel>> GetAllCategory()
        {
            var data = await _dbContext.Categories.Where(s => s.Status > 0).OrderByDescending(a => a.CreatedDate).ToListAsync();
            return data.Adapt<List<CategoryViewModel>>();
        }

        public async Task<bool> UpdateCategory(UpdateCategoryViewModel model)
        {
            var data = _dbContext.Categories.Find(model.ID);
            if (data == null)
            {
                return false;
            }
            data.Name = model.Name;
            data.UpdatedBy = model.UpdatedBy;
            data.LastModifiedDate = DateTime.Now;
            data.Status = model.Status;
            _dbContext.Categories.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return true;
        }
    }
}