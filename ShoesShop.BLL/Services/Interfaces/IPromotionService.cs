using ShoesShop.BLL.Common.ViewModels;
using ShoesShop.BLL.ViewModels.Promotion;

namespace BLL.Services.Interfaces;

public interface IPromotionService
{
    Task<List<PromotionDetailModel>> GetListPromotion();

    Task<PromotionDetailModel> GetDetail(string id);

    Task<PromotionDetailModel> GetDetailByCode(string code);

    Task<bool> Delete(DeleteModel model);

    Task<bool> AddNew(AddNewPromotionModel model);

    Task<bool> Update(UpdatePromotionModel model);
}