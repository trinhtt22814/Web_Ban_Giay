namespace ShoesShop.BLL.ViewModels.CartDetail
{
    public class AddCartDetailViewModel
    {
        public Guid ID { get; set; }
        public Guid IDProductDetail { get; set; }
        public Guid IDUser { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
    }
}