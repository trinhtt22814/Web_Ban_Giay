using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.OrderHistory;
using ShoesShop.DAL.ApplicationDbContext;

namespace ShoesShop.BLL.Services.Implements
{
    public class OrderHistoryServices : IOrderHistoryServices
    {
        private WebDbContext _dbContext;

        public OrderHistoryServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddOrderHistory(AddOrderHistoryViewModel model)
        {
            try
            {
                var data = await _dbContext.OrderHistories.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == model.ID);
                if (data != null)
                {
                    return false;
                }
                await _dbContext.OrderHistories.AddAsync(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteOrderHistory(Guid id)
        {
            try
            {
                var data = await _dbContext.OrderHistories.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == id);
                if (data != null)
                {
                    return false;
                }
                data.Status = 0;
                _dbContext.OrderHistories.Update(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<OrderHistoryViewModel>> GetAllOrderHistory()
        {
            var data = await _dbContext.OrderHistories.Where(s => s.Status > 0).OrderByDescending(a => a.CreatedDate).ToListAsync();
            return data.Adapt<List<OrderHistoryViewModel>>();
        }

        public async Task<bool> UpdateOrderHistory(UpdateOrderHistoryViewModel model)
        {
            var data = _dbContext.OrderHistories.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                return false;
            }
            data.ActionDescription = model.ActionDescription;
            data.UpdatedBy = model.UpdatedBy;
            data.LastModifiedDate = DateTime.Now;
            data.Status = model.Status;
            _dbContext.OrderHistories.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return true;
        }
    }
}