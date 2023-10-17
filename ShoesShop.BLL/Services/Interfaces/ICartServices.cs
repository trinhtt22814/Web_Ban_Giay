using ShoesShop.DAL.Entities;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface ICartServices
    {
        public Task<Cart> GetByUser(Guid userId);

        public Task<bool> Add(Cart model);

        public Task<bool> Delete(Guid userId);
    }
}