using Microsoft.AspNetCore.Mvc;

namespace ShoesShop.Web.Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
