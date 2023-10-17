using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Voucher;
using ShoesShop.DAL.ApplicationDbContext;

namespace ShoesShop.BLL.Services.Implements
{
    public class VoucherServices : IVoucherServices
    {
        private WebDbContext _dbContext;

        public VoucherServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddVoucher(AddVoucherViewModel model)
        {
            try
            {
                var data = await _dbContext.Vouchers.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == model.ID);
                if (data != null)
                {
                    return false;
                }
                await _dbContext.Vouchers.AddAsync(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteVoucher(Guid id)
        {
            try
            {
                var data = await _dbContext.Vouchers.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == id);
                if (data != null)
                {
                    return false;
                }
                data.Status = 0;
                _dbContext.Vouchers.Update(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<VoucherViewModel>> GetAllVoucher()
        {
            var data = await _dbContext.Vouchers.Where(s => s.Status > 0).OrderByDescending(a => a.CreatedDate).ToListAsync();
            return data.Adapt<List<VoucherViewModel>>();
        }

        public async Task<VoucherViewModel> GetVoucherById(Guid id)
        {
            var data = await _dbContext.Vouchers.FirstOrDefaultAsync(x => x.ID == id);
            return data == null ? new VoucherViewModel() : data.Adapt<VoucherViewModel>();
        }

        public async Task<bool> UpdateVoucher(UpdateVoucherViewModel model)
        {
            var data = _dbContext.Vouchers.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                return false;
            }

            data.Name = model.Name;
            data.Code = model.Code;
            data.Quantity = model.Quantity;
            data.Value = model.Value;
            data.EndDate = model.EndDate;
            data.UpdatedBy = model.UpdatedBy;
            data.LastModifiedDate = DateTime.Now;
            data.Status = model.Status;
            _dbContext.Vouchers.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return true;
        }
    }
}