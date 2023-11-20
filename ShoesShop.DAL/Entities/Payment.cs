using ShoesShop.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ShoesShop.DAL.Entities
{
	public class Payment : Audit
	{
		[Required] public decimal Amount { get; set; }
		[Required] public string PaymentMethod { get; set; }
		[Required] public string TransactionId { get; set; }
		[Required] public string PaymentCode { get; set; }
		public DateTime TransactionDate { set; get; }
		public decimal Fee { set; get; }
		public Guid StatusId { get; set; }
	}
}