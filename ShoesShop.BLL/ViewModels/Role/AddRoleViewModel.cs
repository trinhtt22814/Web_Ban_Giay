namespace ShoesShop.BLL.ViewModels.Role
{
    public class AddRoleViewModel
    {
        public Guid ID { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public string RoleName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}