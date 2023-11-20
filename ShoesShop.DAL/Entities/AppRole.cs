using Microsoft.AspNetCore.Identity;

namespace ShoesShop.DAL.Entities
{
	public class AppRole : IdentityRole<Guid>
	{
		public string Description { get; set; }
	}
}