using ShoesShop.BLL.ViewModels.VoucherDetail;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface IVoucherDetailServices
    {
        public Task<bool> AddVoucherDetail(AddVoucherDetailViewModel model);

        public Task<bool> DeleteVoucherDetail(Guid id);

        public Task<bool> UpdateVoucherDetail(UpdateVoucherDetailViewModel model);

        public Task<List<VoucherDetailViewModel>> GetAllVoucherDetail();

        public Task<VoucherDetailViewModel> GetVoucherDetailById(Guid id);
    }
}