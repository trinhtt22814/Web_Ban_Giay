using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Common.ViewModels;
using ShoesShop.BLL.Persistence;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Size;
using ShoesShop.DAL.Entities;
using ShoesShop.DAL.Helpers;

namespace ShoesShop.BLL.Services.Implements
{
	public class SizeServices : ISizeService
	{
		private WebDbContext _dbContext;

		public SizeServices(WebDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<bool> AddNew(AddNewSizeModel model)
		{
			var data = await _dbContext.Sizes
			.FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

			if (data != null)
			{
				return false;
			}

			var newData = model.Adapt<Size>();
			newData.Code = model.Name.VietnameseToNormalString();

			await _dbContext.Sizes.AddAsync(newData);

			await _dbContext.SaveChangesAsync(new CancellationToken());

			return true;
		}

		public async Task<bool> Delete(DeleteModel model)
		{
			var data = await _dbContext.Sizes
			 .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

			if (data == null)
			{
				return false;
			}

			data.IsDeleted = true;

			_dbContext.Sizes.Update(data);
			await _dbContext.SaveChangesAsync(new CancellationToken());

			return true;
		}

		public async Task<SizeDetailModel> GetDetail(string id)
		{
			var data = await _dbContext.Sizes
			.FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == Guid.Parse(id));

			return data == null ? new SizeDetailModel() : data.Adapt<SizeDetailModel>();
		}

		public async Task<List<SizeDetailModel>> GetListSize()
		{
			var data = await _dbContext.Sizes
		   .Where(s => !s.IsDeleted)
		   .OrderByDescending(a => a.CreatedAt)
		   .ToListAsync();

			return data.Adapt<List<SizeDetailModel>>();
		}

		public async Task<bool> Update(UpdateSizeModel model)
		{
			var data = await _dbContext.Sizes
			.FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);

			if (data == null)
			{
				return false;
			}

			data.Name = model.Name;
			data.Code = model.Name.VietnameseToNormalString();

			_dbContext.Sizes.Update(data);

			await _dbContext.SaveChangesAsync(new CancellationToken());

			return true;
		}
	}
}