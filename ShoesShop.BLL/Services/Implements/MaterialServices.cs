using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Material;
using ShoesShop.DAL.ApplicationDbContext;

namespace ShoesShop.BLL.Services.Implements
{
    public class MaterialServices : IMaterialServices
    {
        private WebDbContext _dbContext;

        public MaterialServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddMaterial(AddMaterialViewModel model)
        {
            try
            {
                var data = await _dbContext.Materials.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == model.ID);
                if (data != null)
                {
                    return false;
                }
                await _dbContext.Materials.AddAsync(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteMaterial(Guid id)
        {
            try
            {
                var data = await _dbContext.Materials.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == id);
                if (data != null)
                {
                    return false;
                }
                data.Status = 0;
                _dbContext.Materials.Update(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<MaterialViewModel>> GetAllMaterial()
        {
            var data = await _dbContext.Materials.Where(s => s.Status > 0).OrderByDescending(a => a.CreatedDate).ToListAsync();
            return data.Adapt<List<MaterialViewModel>>();
        }

        public async Task<MaterialViewModel> GetMaterialById(Guid id)
        {
            var data = await _dbContext.Materials.FirstOrDefaultAsync(x => x.ID == id);
            return data == null ? new MaterialViewModel() : data.Adapt<MaterialViewModel>();
        }

        public async Task<bool> UpdateMaterial(UpdateMaterialViewModel model)
        {
            var data = _dbContext.Materials.Find(model.ID);
            if (data == null)
            {
                return false;
            }
            data.Name = model.Name;
            data.UpdatedBy = model.UpdatedBy;
            data.LastModifiedDate = DateTime.Now;
            data.Status = model.Status;
            _dbContext.Materials.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return true;
        }
    }
}