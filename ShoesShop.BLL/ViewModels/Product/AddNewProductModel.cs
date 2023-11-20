using Microsoft.AspNetCore.Http;
using ShoesShop.BLL.ViewModels.Images;
using ShoesShop.BLL.ViewModels.Property;
using System.ComponentModel.DataAnnotations;

namespace ShoesShop.BLL.ViewModels.Product;

public class AddNewProductModel
{
	[Required] public Guid Id { get; set; }
	[Required] public string Name { get; set; }
	public string Description { get; set; }
	[Required] public decimal Price { get; set; }
	public decimal Discount { get; set; }
	[Required] public string Currency { get; set; }
	public List<IFormFile> Images { get; set; }
	public List<PropertyDetailModel>? Properties { get; set; }
	[Required] public Guid BrandId { get; set; }
	[Required] public Guid CategoryId { get; set; }
	[Required] public Guid ColorId { get; set; }
	[Required] public Guid SizeId { get; set; }
	[Required] public Guid MaterialId { get; set; }
	public List<ImageDetailModel> ListImage { get; set; }
}