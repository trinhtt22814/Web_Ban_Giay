using ShoesShop.BLL.ViewModels.Category;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface ICategoryServices
    {
        public Task<List<CategoryViewModel>> GetAllCategory();

        public Task<CategoryViewModel> GetCategoryById(Guid id);

        public Task<bool> DeleteCategory(Guid id);

        public Task<bool> AddCategory(AddCategoryViewModel model);

        public Task<bool> UpdateCategory(UpdateCategoryViewModel model);
    }
}