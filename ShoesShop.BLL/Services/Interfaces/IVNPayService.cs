using Microsoft.AspNetCore.Http;
using ShoesShop.BLL.Common.ViewModels;
using ShoesShop.BLL.ViewModels.Payment;

namespace BLL.Services.Interfaces;

public interface IVNPayService
{
    ResponseUriModel CreatePayment(PaymentInfoModel model, HttpContext context);

    PaymentResponseModel PaymentExecute(IQueryCollection collection);
}