using ShoesShop.BLL.ViewModels.Menu;
using ShoesShop.BLL.ViewModels.Status;

namespace ShoesShop.BLL.Services.Interfaces;

public interface ICommonService
{
    Task<MenuModel> GetMenu(bool isAdmin);

    Task<List<StatusDetailModel>> GetDropdownStatus(string type);
}