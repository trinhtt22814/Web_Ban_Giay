using ShoesShop.BLL.Common.ViewModels;
using ShoesShop.BLL.ViewModels.Categories;

namespace ShoesShop.BLL.Services.Interfaces;

public interface ICategoryService
{
	Task<List<CategoryDetailModel>> GetListCategory();

	Task<CategoryDetailModel> GetDetail(string id);

	Task<bool> Delete(DeleteModel model);

	Task<bool> AddNew(AddNewCategoryModel model);

	Task<bool> Update(UpdateCategoryModel model);
}