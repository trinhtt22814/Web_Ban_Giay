namespace ShoesShop.DAL.Entities
{
    public class OrderDetail
    {
        public Guid ID { get; set; }
        public Guid IDProductDetail { get; set; }
        public Guid IDOrder { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
    }
}