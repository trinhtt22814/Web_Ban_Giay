using ShoesShop.BLL.Common.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ShoesShop.BLL.ViewModels.Size
{
    public class UpdateSizeModel : AuditModel
    {
        [Required] public string Name { get; set; }
        [Required] public string Code { get; set; }
    }
}