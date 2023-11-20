using ShoesShop.DAL.Entities.Base;

namespace ShoesShop.DAL.Entities
{
	public class Raiting : Audit
	{
		public Guid UserId { get; set; }
		public Guid ProductId { get; set; }
		public int StarPoint { get; set; }
	}
}