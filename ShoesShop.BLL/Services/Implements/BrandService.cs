using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Common.ViewModels;
using ShoesShop.BLL.Persistence;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Brands;
using ShoesShop.DAL.Entities;
using ShoesShop.DAL.Helpers;

namespace ShoesShop.BLL.Services.Implements;

public class BrandService : IBrandService
{
	private WebDbContext _dbContext;

	public BrandService(WebDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<List<BrandDetailModel>> GetListBrand()
	{
		var data = await _dbContext.Brands
			.Where(s => !s.IsDeleted)
			.OrderByDescending(a => a.CreatedAt)
			.ToListAsync();

		return data.Adapt<List<BrandDetailModel>>();
	}

	public async Task<BrandDetailModel> GetDetail(string id)
	{
		var data = await _dbContext.Brands
			.FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == Guid.Parse(id));

		return data == null ? new BrandDetailModel() : data.Adapt<BrandDetailModel>();
	}

	public async Task<bool> Delete(DeleteModel model)
	{
		var data = await _dbContext.Brands
			.FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

		if (data == null)
		{
			return false;
		}

		data.IsDeleted = true;

		_dbContext.Brands.Update(data);
		await _dbContext.SaveChangesAsync(new CancellationToken());

		return true;
	}

	public async Task<bool> AddNew(AddNewBrandModel model)
	{
		var data = await _dbContext.Brands
			.FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

		if (data != null)
		{
			return false;
		}

		var newData = model.Adapt<Brand>();
		newData.Code = model.Name.VietnameseToNormalString();

		await _dbContext.Brands.AddAsync(newData);

		await _dbContext.SaveChangesAsync(new CancellationToken());

		return true;
	}

	public async Task<bool> Update(UpdateBrandModel model)
	{
		var data = await _dbContext.Brands
			.FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

		if (data == null)
		{
			return false;
		}

		data.Name = model.Name;
		data.Code = model.Name.VietnameseToNormalString();

		_dbContext.Brands.Update(data);

		await _dbContext.SaveChangesAsync(new CancellationToken());

		return true;
	}
}