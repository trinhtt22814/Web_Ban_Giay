using ShoesShop.BLL.ViewModels.CartDetail;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface ICartDetailServices
    {
        public Task<List<CartDetailViewModel>> GetAllCart(List<CartDetailViewModel> list);

        public Task<CartDetailViewModel> GetById(Guid id);

        public Task<bool> Add(AddCartDetailViewModel model);

        public Task<bool> Update(UpdateCartDetailViewModel model);

        public Task<bool> Delete(Guid id);
    }
}