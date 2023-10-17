using ShoesShop.BLL.ViewModels.PaymentMethod;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface IPaymentMethodServices
    {
        public Task<List<PaymentMethodViewModel>> GetAllPaymentMethod();

        public Task<bool> DeletePaymentMethod(Guid id);

        public Task<bool> AddPaymentMethod(AddPaymentMethodViewModel model);

        public Task<bool> UpdatePaymentMethod(UpdatePaymentMethodViewModel model);
    }
}