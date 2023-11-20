using System.ComponentModel;

namespace ShoesShop.DAL.Enums;

public enum StatusType
{
	[Description("Order")] Order,
	[Description("Product")] Product,
	[Description("Payment")] Payment,
}