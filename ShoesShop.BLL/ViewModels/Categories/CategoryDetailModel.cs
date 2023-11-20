using ShoesShop.BLL.Common.ViewModels;

namespace ShoesShop.BLL.ViewModels.Categories;

public class CategoryDetailModel : AuditModel
{
	public string Name { get; set; }
	public string Code { get; set; }
}