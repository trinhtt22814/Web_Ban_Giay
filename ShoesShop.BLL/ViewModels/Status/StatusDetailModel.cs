using ShoesShop.BLL.Common.ViewModels;

namespace ShoesShop.BLL.ViewModels.Status;

public class StatusDetailModel : AuditModel
{
	public string Type { get; set; }
	public string Display { get; set; }
	public string Code { get; set; }
}