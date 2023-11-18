using ShoesShop.BLL.Common.ViewModels;

namespace ShoesShop.BLL.ViewModels.Brands;

public class BrandDetailModel : AuditModel
{
    public string Name { get; set; }
    public string Code { get; set; }
}