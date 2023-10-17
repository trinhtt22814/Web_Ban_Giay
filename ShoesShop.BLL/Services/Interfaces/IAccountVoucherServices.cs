using ShoesShop.BLL.ViewModels.AccountVoucher;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface IAccountVoucherServices
    {
        public Task<List<AccountVoucherViewModel>> GetAllAccountVoucher();

        public Task<AccountVoucherViewModel> GetAccountVoucherById(Guid id);

        public Task<bool> DeleteAccountVoucher(Guid id);

        public Task<bool> AddAccountVoucher(AddAccountVoucherViewModel model);

        public Task<bool> UpdateAccountVoucher(UpdateAccountVoucherViewModel model);
    }
}