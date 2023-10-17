namespace ShoesShop.DAL.Entities
{
    public class Cart
    {
        public Guid IDUser { get; set; }
        public string Description { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<CartDetail> CartDetail { get; set; }
    }
}