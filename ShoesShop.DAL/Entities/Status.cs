using ShoesShop.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ShoesShop.DAL.Entities
{
    public class Status : Audit
    {
        [Required] public string Type { get; set; }
        [Required] public string Display { get; set; }
        [Required] public string Code { get; set; }
    }
}