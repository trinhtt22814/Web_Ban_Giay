using ShoesShop.BLL.Common.ViewModels;
using ShoesShop.BLL.ViewModels.Color;

namespace ShoesShop.BLL.Services.Interfaces
{
	public interface IColorService
	{
		Task<List<ColorDetailModel>> GetListColor();

		Task<ColorDetailModel> GetDetail(string id);

		Task<bool> Delete(DeleteModel model);

		Task<bool> AddNew(AddNewColorModel model);

		Task<bool> Update(UpdateColorModel model);
	}
}