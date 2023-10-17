using ShoesShop.BLL.ViewModels.Brand;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface IBrandServices
    {
        public Task<List<BrandViewModel>> GetAllBrand();

        public Task<BrandViewModel> GetBrandById(Guid id);

        public Task<bool> DeleteBrand(Guid id);

        public Task<bool> AddBrand(AddBrandViewModel model);

        public Task<bool> UpdateBrand(UpdateBrandViewModel model);
    }
}