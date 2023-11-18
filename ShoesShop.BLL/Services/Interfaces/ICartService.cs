using ShoesShop.BLL.ViewModels.Cart;

namespace BLL.Services.Interfaces;

public interface ICartService
{
    Task<List<CartProductModel>> GetListCart(List<CartProductModel> list);
}