using ShoesShop.BLL.Common.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ShoesShop.BLL.ViewModels.Material
{
	public class AddNewMaterialModel : AuditModel
	{
		[Required] public string Name { get; set; }
		[Required] public string Code { get; set; }
	}
}