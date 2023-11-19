using ShoesShop.BLL.Common.ViewModels;
using ShoesShop.BLL.ViewModels.Brands;

namespace ShoesShop.BLL.Services.Interfaces;

public interface IBrandService
{
    Task<List<BrandDetailModel>> GetListBrand();

    Task<BrandDetailModel> GetDetail(string id);

    Task<bool> Delete(DeleteModel model);

    Task<bool> AddNew(AddNewBrandModel model);

    Task<bool> Update(UpdateBrandModel model);
}