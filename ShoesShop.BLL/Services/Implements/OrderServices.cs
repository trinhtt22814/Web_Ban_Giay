using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Order;
using ShoesShop.DAL.ApplicationDbContext;

namespace ShoesShop.BLL.Services.Implements
{
    public class OrderServices : IOrderServices
    {
        private WebDbContext _dbContext;

        public OrderServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddOrder(AddOrderViewModel model)
        {
            try
            {
                var data = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == model.ID);
                if (data != null)
                {
                    return false;
                }
                await _dbContext.Orders.AddAsync(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteOrder(Guid id)
        {
            try
            {
                var data = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == id);
                if (data != null)
                {
                    return false;
                }
                data.Status = 0;
                _dbContext.Orders.Update(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<OrderViewModel>> GetAllOrder()
        {
            var data = await _dbContext.Orders.Where(s => s.Status > 0).OrderByDescending(a => a.CreatedDate).ToListAsync();
            return data.Adapt<List<OrderViewModel>>();
        }

        public async Task<OrderViewModel> GetOrderById(Guid id)
        {
            var data = await _dbContext.Orders.FirstOrDefaultAsync(x => x.ID == id);
            return data == null ? new OrderViewModel() : data.Adapt<OrderViewModel>();
        }

        public async Task<bool> UpdateOrder(UpdateOrderViewModel model)
        {
            var data = _dbContext.Orders.Find(model.ID);
            if (data == null)
            {
                return false;
            }

            data.PhoneNumber = model.PhoneNumber;
            data.DeliveryAddress = model.DeliveryAddress;
            data.Username = model.Username;
            data.ItemDiscount = model.ItemDiscount;
            data.TotalMoney = model.TotalMoney;
            data.ConfirmationDate = DateTime.Now;
            data.Type = model.Type;
            data.Note = model.Note;
            data.UpdatedBy = model.UpdatedBy;
            data.LastModifiedDate = DateTime.Now;
            data.Status = model.Status;
            _dbContext.Orders.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return true;
        }
    }
}