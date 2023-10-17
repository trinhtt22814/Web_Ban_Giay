using ShoesShop.BLL.ViewModels.Image;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface IImageServices
    {
        public Task<List<ImageViewModel>> GetImageByProduct(Guid idProduct);

        public Task<bool> DeleteImage(Guid id);

        public Task<bool> AddImage(AddImageViewModel model);

        public Task<bool> UpdateImage(UpdateImageViewModel model);
    }
}