﻿using System.ComponentModel;

namespace ShoesShop.DAL.Enums;

public enum ProductStatus
{
	// Code
	[Description("Available")] AvailableCode,

	[Description("NotAvailable")] NotAvailableCode,

	// Display
	[Description("Hiển thị")] AvailableDisplayVN,

	[Description("Không hiển thị")] NotAvailableDisplayVN,

	// Display
	[Description("Available")] AvailableDisplayEN,

	[Description("Not Available")] NotAvailableDisplayEN,
}