using System.ComponentModel.DataAnnotations;

namespace ShoesShop.BLL.ViewModels.User;

public class UpdateUserRole
{
    [Required] public string Id { get; set; }
    [Required] public List<string> Roles { get; set; }
}