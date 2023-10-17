namespace ShoesShop.DAL.Entities
{
    public class CartDetail
    {
        public Guid ID { get; set; }
        public Guid IDProductDetail { get; set; }
        public Guid IDUser { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
        public virtual Cart Cart { get; set; }
    }
}