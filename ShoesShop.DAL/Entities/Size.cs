using ShoesShop.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ShoesShop.DAL.Entities
{
    public class Size : Audit
    {
        [Required][MaxLength(500)] public string Name { get; set; }
        [Required][MaxLength(500)] public string Code { get; set; }
    }
}