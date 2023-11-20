using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoesShop.DAL.Constants;

namespace ShoesShop.Web.Client.Areas.Admin.Controllers;

[Authorize(Roles = SecurityRoles.Manager)]
public class HomeController : BaseAdminController
{
	// GET
	public IActionResult Index()
	{
		return View();
	}
}