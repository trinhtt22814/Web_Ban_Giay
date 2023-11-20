using ShoesShop.BLL.Common.ViewModels;
using ShoesShop.BLL.ViewModels.Material;

namespace ShoesShop.BLL.Services.Interfaces
{
	public interface IMaterialService
	{
		Task<List<MaterialDetailModel>> GetListMaterial();

		Task<MaterialDetailModel> GetDetail(string id);

		Task<bool> Delete(DeleteModel model);

		Task<bool> AddNew(AddNewMaterialModel model);

		Task<bool> Update(UpdateMaterialModel model);
	}
}