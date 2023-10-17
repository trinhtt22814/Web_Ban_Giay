using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.OrderDetail;
using ShoesShop.DAL.ApplicationDbContext;
using ShoesShop.DAL.Entities;

namespace ShoesShop.BLL.Services.Implements
{
    public class OrderDetailServices : IOrderDetailServices
    {
        private WebDbContext _dbContext;
        private OrderServices _orderServices;
        private ProductDetailServices _productDetailServices;

        public OrderDetailServices(WebDbContext dbContext, OrderServices orderServices, ProductDetailServices productDetailServices)
        {
            _dbContext = dbContext;
            _orderServices = orderServices;
            _productDetailServices = productDetailServices;
        }

        public async Task<bool> AddOrderDetail(AddOrderDetailViewModel model)
        {
            try
            {
                var obj = new OrderDetail()
                {
                    IDOrder = model.IDOrder,
                    IDProductDetail = model.IDProductDetail,
                    Price = model.Price,
                    Quantity = model.Quantity,
                };
                await _dbContext.OrderDetails.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateOrderDetail(UpdateOrderDetailViewModel model)
        {
            try
            {
                var data = _dbContext.OrderDetails.FirstOrDefault(x => x.ID == model.ID);
                if (data == null)
                {
                    return false;
                }
                data.Quantity = model.Quantity;
                _dbContext.OrderDetails.Update(data);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}