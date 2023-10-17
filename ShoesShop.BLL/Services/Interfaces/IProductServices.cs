using ShoesShop.BLL.ViewModels.Product;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface IProductServices
    {
        public Task<List<ProductViewModel>> GetAllProduct();

        public Task<ProductViewModel> GetProductById(Guid id);

        public Task<bool> DeleteProduct(Guid id);

        public Task<bool> AddProduct(AddProductViewModel model);

        public Task<bool> UpdateProduct(UpdateProductViewModel model);
    }
}