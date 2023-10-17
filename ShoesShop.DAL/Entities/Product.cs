using ShoesShop.DAL.Entities.Base;

namespace ShoesShop.DAL.Entities
{
    public class Product : BaseID
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<ProductDetail> ProductDetail { get; set; }
    }
}