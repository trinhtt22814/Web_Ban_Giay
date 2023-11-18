using ShoesShop.BLL.Common.ViewModels;

namespace ShoesShop.BLL.ViewModels.Images;

public class ImageDetailModel : AuditModel
{
    public string? OriginLinkImage { get; set; }
    public string? LocalLinkImage { get; set; }
    public Guid ProductId { get; set; }
}