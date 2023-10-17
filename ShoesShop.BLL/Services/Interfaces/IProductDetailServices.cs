using ShoesShop.BLL.ViewModels.ProductDetail;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface IProductDetailServices
    {
        public Task<List<ProductDetailViewModel>> GetAllProductDetail();

        public Task<ProductDetailViewModel> GetProductDetailById(Guid id);

        public Task<bool> AddProductDetail(AddProductDetailViewModel model);

        public Task<bool> UpdateProductDetail(UpdateProductDetailViewModel model);

        public Task<bool> DeleteProductDetail(Guid id);
    }
}