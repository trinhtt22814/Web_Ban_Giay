using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.VoucherDetail;
using ShoesShop.DAL.ApplicationDbContext;

namespace ShoesShop.BLL.Services.Implements
{
    public class VoucherDetailServices : IVoucherDetailServices
    {
        private WebDbContext _dbContext;

        public VoucherDetailServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddVoucherDetail(AddVoucherDetailViewModel model)
        {
            try
            {
                var data = await _dbContext.VoucherDetails.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == model.ID);
                if (data != null)
                {
                    return false;
                }
                await _dbContext.VoucherDetails.AddAsync(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteVoucherDetail(Guid id)
        {
            try
            {
                var data = await _dbContext.VoucherDetails.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == id);
                if (data != null)
                {
                    return false;
                }
                data.Status = 0;
                _dbContext.VoucherDetails.Update(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<VoucherDetailViewModel>> GetAllVoucherDetail()
        {
            var data = await _dbContext.VoucherDetails.Where(s => s.Status > 0).OrderByDescending(a => a.CreatedDate).ToListAsync();
            return data.Adapt<List<VoucherDetailViewModel>>();
        }

        public async Task<VoucherDetailViewModel> GetVoucherDetailById(Guid id)
        {
            var data = await _dbContext.VoucherDetails.FirstOrDefaultAsync(x => x.ID == id);
            return data == null ? new VoucherDetailViewModel() : data.Adapt<VoucherDetailViewModel>();
        }

        public async Task<bool> UpdateVoucherDetail(UpdateVoucherDetailViewModel model)
        {
            var data = _dbContext.VoucherDetails.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                return false;
            }
            data.DiscountPrice = model.DiscountPrice;
            data.AfterPrice = model.AfterPrice;
            data.UpdatedBy = model.UpdatedBy;
            data.LastModifiedDate = DateTime.Now;
            data.Status = model.Status;
            _dbContext.VoucherDetails.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return true;
        }
    }
}