namespace ShoesShop.DAL.Entities
{
    public class Role
    {
        public Guid ID { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public string RoleName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
    }
}