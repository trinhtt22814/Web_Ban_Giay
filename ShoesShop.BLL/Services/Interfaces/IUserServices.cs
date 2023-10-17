using ShoesShop.BLL.ViewModels.User;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface IUserServices
    {
        public Task<bool> AddUser(AddUserViewModel model);

        public Task<bool> DeleteUser(Guid id);

        public Task<bool> UpdateUser(UpdateUserViewModel model);

        public Task<List<UserViewModel>> GetAllUser();

        public Task<UserViewModel> GetUserById(Guid id);
    }
}