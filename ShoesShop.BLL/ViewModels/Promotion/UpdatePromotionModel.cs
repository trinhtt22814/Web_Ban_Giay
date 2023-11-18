using ShoesShop.BLL.Common.ViewModels;

namespace ShoesShop.BLL.ViewModels.Promotion;

public class UpdatePromotionModel : AuditModel
{
    public int DiscountPercent { set; get; }
}