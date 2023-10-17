namespace ShoesShop.BLL.ViewModels.CartDetail
{
    public class CartDetailViewModel
    {
        public Guid ID { get; set; }
        public Guid IDProductDetail { get; set; }
        public Guid IDUser { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int TotalPriceEachItem { get; set; }
        public int TotalPriceAll { get; set; }
        public string Image { get; set; }
    }
}