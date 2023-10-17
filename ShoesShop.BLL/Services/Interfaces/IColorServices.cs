using ShoesShop.BLL.ViewModels.Color;

namespace ShoesShop.BLL.Services.Interfaces
{
    public interface IColorServices
    {
        public Task<List<ColorViewModel>> GetAllColor();

        public Task<ColorViewModel> GetColorById(Guid id);

        public Task<bool> DeleteColor(Guid id);

        public Task<bool> AddColor(AddColorViewModel model);

        public Task<bool> UpdateColor(UpdateColorViewModel model);
    }
}