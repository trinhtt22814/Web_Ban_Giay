using ShoesShop.DAL.Entities.Base;

namespace ShoesShop.DAL.Entities
{
    public class Image : BaseID
    {
        public Guid IDProductDetail { get; set; }
        public string Name { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
    }
}