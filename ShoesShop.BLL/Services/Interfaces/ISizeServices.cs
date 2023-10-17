using ShoesShop.BLL.ViewModels.Size;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface ISizeServices
    {
        public Task<List<SizeViewModel>> GetAllSize();

        public Task<SizeViewModel> GetSizeById(Guid id);

        public Task<bool> DeleteSize(Guid id);

        public Task<bool> AddSize(AddSizeViewModel model);

        public Task<bool> UpdateSize(UpdateSizeViewModel model);
    }
}