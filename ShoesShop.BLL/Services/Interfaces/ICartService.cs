using ShoesShop.BLL.ViewModels.Cart;

namespace ShoesShop.BLL.Services.Interfaces;

public interface ICartService
{
    Task<List<CartProductModel>> GetListCart(List<CartProductModel> list);
}