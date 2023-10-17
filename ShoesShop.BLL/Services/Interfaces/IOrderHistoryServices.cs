using ShoesShop.BLL.ViewModels.OrderHistory;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface IOrderHistoryServices
    {
        public Task<List<OrderHistoryViewModel>> GetAllOrderHistory();

        public Task<bool> DeleteOrderHistory(Guid id);

        public Task<bool> AddOrderHistory(AddOrderHistoryViewModel model);

        public Task<bool> UpdateOrderHistory(UpdateOrderHistoryViewModel model);
    }
}