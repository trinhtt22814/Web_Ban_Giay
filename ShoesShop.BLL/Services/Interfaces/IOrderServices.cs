using ShoesShop.BLL.ViewModels.Order;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface IOrderServices
    {
        public Task<List<OrderViewModel>> GetAllOrder();

        public Task<OrderViewModel> GetOrderById(Guid id);

        public Task<bool> AddOrder(AddOrderViewModel model);

        public Task<bool> UpdateOrder(UpdateOrderViewModel model);

        public Task<bool> DeleteOrder(Guid id);
    }
}