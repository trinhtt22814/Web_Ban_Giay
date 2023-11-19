using ShoesShop.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Checkout;
using ShoesShop.BLL.ViewModels.Order;
using ShoesShop.BLL.ViewModels.Payment;

namespace ShoesShop.Web.Client.Controllers;

public class PaymentController : BaseController
{
    private readonly IVNPayService _vnPayService;
    private readonly ICartService _cartService;
    private readonly IOrderService _orderService;

    public PaymentController(IVNPayService vnPayService, ICartService cartService, IOrderService orderService)
    {
        _vnPayService = vnPayService;
        _cartService = cartService;
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> ProcessCheckout([FromBody] CheckoutModel request)
    {
        var paymentCode = Guid.NewGuid().ToString().Split("-")[0];
        var carts = await _cartService.GetListCart(request.Carts);

        if (!(carts?.Count > 0)) return BadRequestResponse("Cart is empty");

        switch (request.PaymentMethod.ToLower())
        {
            case "vnpay":
                var responseUriVnPay = _vnPayService.CreatePayment(new PaymentInfoModel()
                {
                    TotalAmount = (double)carts.First().TotalPriceAll,
                    PaymentCode = paymentCode
                }, HttpContext);
                return SuccessResponse(responseUriVnPay.Uri);

            case "cash":
                return SuccessResponse($"/Home/PaymentCallback?success=true&paymentMethod=Cash");

            default:
                return BadRequestResponse("Invalid payment method");
        }
    }

    public async Task<IActionResult> PaymentCallback()
    {
        var queryCollection = Request.Query;

        if (queryCollection?.Count == 0 || queryCollection == null)
            return Redirect("/Home/PaymentCallback?success=false");

        var paymentMethod = queryCollection.FirstOrDefault(t => t.Key.Contains("payment_method")).Value
            .ToString().ToLower();

        switch (paymentMethod)
        {
            case "vnpay":
                var vnPayResponse = _vnPayService.PaymentExecute(Request.Query);
                return Redirect(!vnPayResponse.Success
                    ? "/Home/PaymentCallback?success=false&paymentMethod=VnPay"
                    : "/Home/PaymentCallback?success=true&paymentMethod=VnPay");

            default:
                return Redirect("/");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CompleteOrder([FromBody] AddNewOrderModel request)
    {
        try
        {
            var carts = await _cartService.GetListCart(request.Carts);
            request.Carts = carts;
            var data = await _orderService.AddNew(request);
            return Ok(data);
        }
        catch (Exception e)
        {
            throw;
        }
    }
}