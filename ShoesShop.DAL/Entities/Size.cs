using ShoesShop.DAL.Entities.Base;

namespace ShoesShop.DAL.Entities
{
    public class Size : BaseID

    {
        public string Name { get; set; }
        public virtual IEnumerable<ProductDetail> ProductDetail { get; set; }
    }
}