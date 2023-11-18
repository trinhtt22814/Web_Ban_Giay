using ShoesShop.BLL.Common.ViewModels;
using ShoesShop.BLL.ViewModels.Status;

namespace ShoesShop.BLL.ViewModels.Order;

public class OrderFilterModel : AuditModel
{
    public OrderDetailModel OrderDetail { get; set; }
    public List<StatusDetailModel> ListOrderStatus { get; set; }
    public List<StatusDetailModel> ListPaymentStatus { get; set; }
}