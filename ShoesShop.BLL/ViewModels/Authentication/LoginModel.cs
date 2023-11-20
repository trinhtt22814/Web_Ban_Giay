using System.ComponentModel.DataAnnotations;

namespace ShoesShop.BLL.ViewModels.Authentication;

public class LoginModel
{
	[Required] public string UserName { get; set; }
	[Required] public string Password { get; set; }
}