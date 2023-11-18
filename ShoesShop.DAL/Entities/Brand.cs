using ShoesShop.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ShoesShop.DAL.Entities
{
    public class Brand : Audit
    {
        [Required][MaxLength(500)] public string Name { get; set; }
        [Required][MaxLength(255)] public string Code { get; set; }
    }
}