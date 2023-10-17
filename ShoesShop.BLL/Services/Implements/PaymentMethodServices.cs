using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.PaymentMethod;
using ShoesShop.DAL.ApplicationDbContext;

namespace ShoesShop.BLL.Services.Implements
{
    public class PaymentMethodServices : IPaymentMethodServices
    {
        private WebDbContext _dbContext;

        public PaymentMethodServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddPaymentMethod(AddPaymentMethodViewModel model)
        {
            try
            {
                var data = await _dbContext.PaymentMethods.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == model.ID);
                if (data != null)
                {
                    return false;
                }
                await _dbContext.PaymentMethods.AddAsync(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletePaymentMethod(Guid id)
        {
            try
            {
                var data = await _dbContext.PaymentMethods.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == id);
                if (data != null)
                {
                    return false;
                }
                data.Status = 0;
                _dbContext.PaymentMethods.Update(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<PaymentMethodViewModel>> GetAllPaymentMethod()
        {
            var data = await _dbContext.PaymentMethods.Where(s => s.Status > 0).OrderByDescending(a => a.CreatedDate).ToListAsync();
            return data.Adapt<List<PaymentMethodViewModel>>();
        }

        public async Task<bool> UpdatePaymentMethod(UpdatePaymentMethodViewModel model)
        {
            var data = _dbContext.PaymentMethods.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                return false;
            }
            data.Method = model.Method;
            data.Description = model.Description;
            data.UpdatedBy = model.UpdatedBy;
            data.LastModifiedDate = DateTime.Now;
            data.Status = model.Status;
            _dbContext.PaymentMethods.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return true;
        }
    }
}