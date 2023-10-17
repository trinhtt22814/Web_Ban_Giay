using ShoesShop.BLL.ViewModels.Role;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface IRoleServices
    {
        public Task<List<RoleViewModel>> GetAllRole();

        public Task<RoleViewModel> GetRoleById(Guid id);

        public Task<bool> DeleteRole(Guid id);

        public Task<bool> AddRole(AddRoleViewModel model);

        public Task<bool> UpdateRole(UpdateRoleViewModel model);
    }
}