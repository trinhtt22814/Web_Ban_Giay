namespace ShoesShop.BLL.ViewModels.OrderDetail
{
    public class AddOrderDetailViewModel
    {
        public Guid ID { get; set; }
        public Guid IDProductDetail { get; set; }
        public Guid IDOrder { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}