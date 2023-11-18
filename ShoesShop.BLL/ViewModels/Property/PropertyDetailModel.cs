using ShoesShop.BLL.Common.ViewModels;

namespace ShoesShop.BLL.ViewModels.Property;

public class PropertyDetailModel : AuditModel
{
    public string Name { get; set; }
    public string Value { get; set; }
    public Guid? ProductId { get; set; }
}