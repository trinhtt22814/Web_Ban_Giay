using ShoesShop.BLL.Common.ViewModels;

namespace ShoesShop.BLL.ViewModels.Material
{
	public class MaterialDetailModel : AuditModel
	{
		public string Name { get; set; }
		public string Code { get; set; }
	}
}