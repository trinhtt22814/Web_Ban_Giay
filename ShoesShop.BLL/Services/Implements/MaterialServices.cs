using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Common.ViewModels;
using ShoesShop.BLL.Persistence;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Material;
using ShoesShop.DAL.Entities;
using ShoesShop.DAL.Helpers;

namespace ShoesShop.BLL.Services.Implements
{
    public class MaterialServices : IMaterialService
    {
        private WebDbContext _dbContext;

        public MaterialServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddNew(AddNewMaterialModel model)
        {
            var data = await _dbContext.Materials
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

            if (data != null)
            {
                return false;
            }

            var newData = model.Adapt<Material>();
            newData.Code = model.Name.VietnameseToNormalString();

            await _dbContext.Materials.AddAsync(newData);

            await _dbContext.SaveChangesAsync(new CancellationToken());

            return true;
        }

        public async Task<bool> Delete(DeleteModel model)
        {
            var data = await _dbContext.Materials
             .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

            if (data == null)
            {
                return false;
            }

            data.IsDeleted = true;

            _dbContext.Materials.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());

            return true;
        }

        public async Task<MaterialDetailModel> GetDetail(string id)
        {
            var data = await _dbContext.Materials
           .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == Guid.Parse(id));

            return data == null ? new MaterialDetailModel() : data.Adapt<MaterialDetailModel>();
        }

        public async Task<List<MaterialDetailModel>> GetListMaterial()
        {
            var data = await _dbContext.Materials
           .Where(s => !s.IsDeleted)
           .OrderByDescending(a => a.CreatedAt)
           .ToListAsync();

            return data.Adapt<List<MaterialDetailModel>>();
        }

        public async Task<bool> Update(UpdateMaterialModel model)
        {
            var data = await _dbContext.Materials
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

            if (data == null)
            {
                return false;
            }

            data.Name = model.Name;
            data.Code = model.Name.VietnameseToNormalString();

            _dbContext.Materials.Update(data);

            await _dbContext.SaveChangesAsync(new CancellationToken());

            return true;
        }
    }
}