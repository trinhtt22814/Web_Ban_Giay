using ShoesShop.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ShoesShop.DAL.Entities
{
    public class Property : Audit
    {
        [Required] public string Name { get; set; }
        [Required] public string Value { get; set; }
        [Required] public Guid ProductId { get; set; }
    }
}