using ShoesShop.DAL.Entities.Base;

namespace ShoesShop.DAL.Entities
{
    public class OrderHistory : BaseID
    {
        public Guid IdOrder { get; set; }
        public string ActionDescription { get; set; }
        public virtual Order Order { get; set; }
    }
}