using ShoesShop.BLL.Common.ViewModel;

namespace ShoesShop.BLL.ViewModels.User
{
    public class UpdateUserViewModel : BaseIDViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; }
    }
}