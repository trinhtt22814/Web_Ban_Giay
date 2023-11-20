using ShoesShop.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ShoesShop.DAL.Entities
{
	public class Image : Audit
	{
		public Guid ProductId { get; set; }
		[MaxLength(500)] public string? OriginLinkImage { get; set; }
		[MaxLength(500)] public string? LocalLinkImage { get; set; }
	}
}