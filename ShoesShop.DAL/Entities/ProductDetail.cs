using ShoesShop.DAL.Entities.Base;

namespace ShoesShop.DAL.Entities
{
    public class ProductDetail : BaseID
    {
        public Guid IDCategory { get; set; }
        public Guid IDSize { get; set; }
        public Guid IDProduct { get; set; }
        public Guid IDMaterial { get; set; }
        public Guid IDBrand { get; set; }
        public Guid IDColor { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string DefaultImage { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public virtual List<Image> Images { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual Category Category { get; set; }
        public virtual Size Size { get; set; }
        public virtual Product Product { get; set; }
        public virtual Color Color { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Material Material { get; set; }
    }
}