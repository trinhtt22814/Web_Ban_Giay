using ShoesShop.DAL.Entities.Base;

namespace ShoesShop.DAL.Entities
{
    public class User : BaseID
    {
        public Guid IDRole { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; }
        public virtual Role Role { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual IEnumerable<Order> Order { get; set; }
        public virtual IEnumerable<AccountVoucher> AccountVoucher { get; set; }
    }
}