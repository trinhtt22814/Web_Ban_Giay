﻿using Microsoft.AspNetCore.Mvc;

namespace ShoesShop.Web.Client.Controllers;

public class BaseController : Controller
{
	[NonAction]
	protected ActionResult BadRequestResponse(string message)
	{
		return new BadRequestObjectResult(message);
	}

	[NonAction]
	protected ActionResult NotFondResponse(string message)
	{
		return new NotFoundObjectResult(message);
	}

	[NonAction]
	protected ActionResult SuccessResponse(string message)
	{
		return new ObjectResult(message);
	}
}