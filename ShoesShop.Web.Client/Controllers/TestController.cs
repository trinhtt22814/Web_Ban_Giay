using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ShoesShop.BLL.Services.Interfaces;

namespace ShoesShop.Web.Client.Controllers;

public class TestController : BaseController
{
    private readonly IInitDataService _initDataService;
    private readonly IIdentityService _identityService;
    private readonly ICategoryService _categoryService;
    private readonly IPromotionService _promotionService;
    private readonly ICommonService _commonService;
    private readonly IOrderService _orderService;
    private readonly IColorService _colorService;
    private readonly ISizeService _sizeService;
    private readonly IMaterialService _materialService;

    public TestController(IInitDataService initDataService
        , IIdentityService identityService
        , ICategoryService categoryService
        , ICommonService commonService
        , IPromotionService promotionService
        , IOrderService orderService
        , IColorService colorService
        , ISizeService sizeService
        , IMaterialService materialService)
    {
        _initDataService = initDataService;
        _identityService = identityService;
        _categoryService = categoryService;
        _commonService = commonService;
        _promotionService = promotionService;
        _orderService = orderService;
        _colorService = colorService;
        _sizeService = sizeService;
        _materialService = materialService;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _orderService.Detail("5BC46071-340D-4AA7-B833-FE51ADB80929");

        return Json(data);
    }
}