using ShoesShop.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ShoesShop.DAL.Entities
{
    public class Promotion : Audit
    {
        [Required] public string Code { get; set; }
        public int DiscountPercent { set; get; }
    }
}