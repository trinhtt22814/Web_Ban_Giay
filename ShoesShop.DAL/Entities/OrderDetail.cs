using ShoesShop.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ShoesShop.DAL.Entities
{
    public class OrderDetail : Audit
    {
        [Required] public int Quantity { get; set; }
        [Required] public decimal Price { set; get; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Guid PromotionId { get; set; }
    }
}