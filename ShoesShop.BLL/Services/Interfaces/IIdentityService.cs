using ShoesShop.BLL.Common.ViewModels;

namespace ShoesShop.BLL.Services.Interfaces;

public interface IIdentityService
{
    CurrentUserModel GetCurrentUserLogin();

    bool IsUnAuthorized();

    bool IsInRoleAsync(string role);

    bool IsEmailConfirmed();
}