using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.AccountVoucher;
using ShoesShop.DAL.ApplicationDbContext;

namespace ShoesShop.BLL.Services.Implements
{
    public class AccountVoucherServices : IAccountVoucherServices
    {
        private WebDbContext _dbContext;

        public AccountVoucherServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAccountVoucher(AddAccountVoucherViewModel model)
        {
            try
            {
                var data = await _dbContext.AccountVouchers.FirstOrDefaultAsync(x => x.ID == model.ID);
                if (data != null)
                {
                    return false;
                }
                await _dbContext.AccountVouchers.AddAsync(data);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAccountVoucher(Guid id)
        {
            try
            {
                var data = await _dbContext.AccountVouchers.FirstOrDefaultAsync(x => x.ID == id);
                if (data != null)
                {
                    return false;
                }
                data.IsDeleted = true;
                _dbContext.AccountVouchers.Update(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<AccountVoucherViewModel> GetAccountVoucherById(Guid id)
        {
            var data = await _dbContext.AccountVouchers.FirstOrDefaultAsync(x => x.ID == id);
            return data == null ? new AccountVoucherViewModel() : data.Adapt<AccountVoucherViewModel>();
        }

        public async Task<List<AccountVoucherViewModel>> GetAllAccountVoucher()
        {
            var data = await _dbContext.AccountVouchers.Where(x => !x.IsDeleted && x.Status > 0).OrderByDescending(x => x.CreatedDate).ToListAsync();
            return data.Adapt<List<AccountVoucherViewModel>>();
        }

        public async Task<bool> UpdateAccountVoucher(UpdateAccountVoucherViewModel model)
        {
            var data = await _dbContext.AccountVouchers
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.ID == model.ID);

            if (data == null)
            {
                return false;
            }
            data.IsDeleted = model.IsDeleted;
            data.UpdatedBy = model.UpdatedBy;
            data.LastModifiedDate = DateTime.Now;
            data.Status = model.Status;

            _dbContext.AccountVouchers.Update(data);

            await _dbContext.SaveChangesAsync(new CancellationToken());

            return true;
        }
    }
}