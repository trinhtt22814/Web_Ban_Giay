using ShoesShop.BLL.Common.ViewModels;
using ShoesShop.BLL.ViewModels.Size;

namespace ShoesShop.BLL.Services.Interfaces
{
	public interface ISizeService
	{
		Task<List<SizeDetailModel>> GetListSize();

		Task<SizeDetailModel> GetDetail(string id);

		Task<bool> Delete(DeleteModel model);

		Task<bool> AddNew(AddNewSizeModel model);

		Task<bool> Update(UpdateSizeModel model);
	}
}