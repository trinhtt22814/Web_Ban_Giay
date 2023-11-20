using ShoesShop.BLL.ViewModels.Product;

namespace ShoesShop.BLL.Services.Interfaces;

public interface IProductService
{
	Task<List<ProductDetailModel>> GetListProduct();

	Task<bool> AddNew(AddNewProductModel model);

	Task<bool> Delete(Guid id);

	Task<ProductDetailModel> Detail(string id);

	Task<List<ProductDetailModel>> GetListSearch(string search);

	Task<List<ProductDetailModel>> GetListCategoryOrBrand(string type, string typeValue);

	List<ProductDetailModel> GetListRangePrice(List<ProductDetailModel> list, decimal? min, decimal? max);

	Task<bool> Update(UpdateProductModel model);

	Task<ProductDetailModel> DetailByUrl(string url);
}