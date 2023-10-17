using ShoesShop.DAL.Entities.Base;

namespace ShoesShop.DAL.Entities
{
    public class PaymentMethod : BaseID
    {
        public Guid IDOrder { get; set; }
        public string Method { get; set; }
        public string Description { get; set; }
        public virtual Order Order { get; set; }
    }
}