using Microsoft.AspNetCore.Mvc;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Cart;

namespace ShoesShop.Web.Client.Controllers;

public class CartController : BaseController
{
	private readonly ICartService _cartService;
	private readonly IIdentityService _identityService;

	public CartController(ICartService cartService, IIdentityService identityService)
	{
		_cartService = cartService;
		_identityService = identityService;
	}

	[HttpPost]
	public async Task<IActionResult> GetCart([FromBody] List<CartProductModel> request)
	{
		var data = await _cartService.GetListCart(request);
		return PartialView("_CartListPartial", data);
	}

	[HttpPost]
	public async Task<IActionResult> GetCartFromCheckout([FromBody] List<CartProductModel> request)
	{
		var data = await _cartService.GetListCart(request);
		return PartialView("_GetCartFromCheckoutPartial", data);
	}

	// GET
	public IActionResult Index()
	{
		return View();
	}

	// GET
	public IActionResult Checkout()
	{
		var currentUser = _identityService.GetCurrentUserLogin();
		return View(currentUser);
	}
}