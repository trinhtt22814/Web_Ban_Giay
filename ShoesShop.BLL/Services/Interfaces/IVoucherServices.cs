using ShoesShop.BLL.ViewModels.Voucher;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface IVoucherServices
    {
        public Task<List<VoucherViewModel>> GetAllVoucher();

        public Task<VoucherViewModel> GetVoucherById(Guid id);

        public Task<bool> AddVoucher(AddVoucherViewModel model);

        public Task<bool> DeleteVoucher(Guid id);

        public Task<bool> UpdateVoucher(UpdateVoucherViewModel model);
    }
}