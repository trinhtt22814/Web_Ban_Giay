using ShoesShop.BLL.ViewModels.User;

namespace ShoesShop.BLL.Services.Interfaces;

public interface IUserService
{
	Task<List<UserDetailModel>> GetUsers();

	Task<bool> Delete(string id);

	Task<UserDetailModel> GetDetail(string userId);
}