using Microsoft.AspNetCore.Mvc;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.DAL.Constants;

namespace ShoesShop.Web.Client.Controllers;

public class HomeController : BaseController
{
    private readonly IConfiguration _configuration;
    private readonly IProductService _productService;

    public HomeController(IConfiguration configuration, IProductService productService)
    {
        _configuration = configuration;
        _productService = productService;
        AppVersion.IsEnglishVersion = _configuration.GetValue<bool>("IsEnglishVersion");
    }

    public async Task<IActionResult> Index()
    {
        var data = await _productService.GetListProduct();
        data = data.OrderByDescending(s => s.CreatedAt).ToList();
        return View(data);
    }

    public async Task<IActionResult> PaymentCallback(string success, string paymentMethod)
    {
        var data = await _productService.GetListProduct();
        data = data.OrderByDescending(s => s.CreatedAt).ToList();
        return View(data);
    }
}