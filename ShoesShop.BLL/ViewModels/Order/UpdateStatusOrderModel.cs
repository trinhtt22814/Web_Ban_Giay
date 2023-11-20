using ShoesShop.BLL.Common.ViewModels;

namespace ShoesShop.BLL.ViewModels.Order;

public class UpdateStatusOrderModel : AuditModel
{
	public Guid OrderId { get; set; }
	public Guid StatusOrderId { get; set; }
	public Guid StatusPaymentId { get; set; }
}