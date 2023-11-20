using ShoesShop.BLL.Common.ViewModels;

namespace ShoesShop.BLL.ViewModels.Promotion;

public class PromotionDetailModel : AuditModel
{
	public string Code { get; set; }
	public int DiscountPercent { set; get; }
}