using ShoesShop.BLL.ViewModels.OrderDetail;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface IOrderDetailServices
    {
        public Task<bool> AddOrderDetail(AddOrderDetailViewModel model);

        public Task<bool> UpdateOrderDetail(UpdateOrderDetailViewModel model);
    }
}