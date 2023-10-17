using ShoesShop.BLL.ViewModels.Material;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface IMaterialServices
    {
        public Task<List<MaterialViewModel>> GetAllMaterial();

        public Task<MaterialViewModel> GetMaterialById(Guid id);

        public Task<bool> DeleteMaterial(Guid id);

        public Task<bool> AddMaterial(AddMaterialViewModel model);

        public Task<bool> UpdateMaterial(UpdateMaterialViewModel model);
    }
}