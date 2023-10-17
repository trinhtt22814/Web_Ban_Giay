using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.CartDetail;
using ShoesShop.DAL.ApplicationDbContext;
using ShoesShop.DAL.Entities;

namespace ShoesShop.BLL.Services.Implements
{
    public class CartDetailServices : ICartDetailServices
    {
        private WebDbContext _dbContext;
        private ProductServices _productServices;

        public CartDetailServices(WebDbContext dbContext, ProductServices productServices)
        {
            _dbContext = dbContext;

            _productServices = productServices;
        }

        public async Task<bool> Add(AddCartDetailViewModel model)
        {
            try
            {
                var obj = new CartDetail()
                {
                    IDProductDetail = model.IDProductDetail,
                    IDUser = model.IDUser,
                    Price = model.Price,
                    Quantity = model.Quantity,
                };
                await _dbContext.CartDetails.AddAsync(obj);
                await
                    _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var data = _dbContext.CartDetails.Find(id);
                data.Status = 0;
                _dbContext.CartDetails.Update(data);
                await
                    _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<CartDetailViewModel> GetById(Guid id)
        {
            var obj = await _dbContext.CartDetails.FirstOrDefaultAsync(x => x.ID == id);
            return new CartDetailViewModel()
            {
                ID = obj.ID,
                IDProductDetail = obj.IDProductDetail,
                IDUser = obj.IDUser,
                Price = obj.Price,
                Quantity = obj.Quantity,
            };
        }

        public async Task<List<CartDetailViewModel>> GetAllCart(List<CartDetailViewModel> list)
        {
            var productlist = await _dbContext.ProductDetails.Where(s => s.Status > 0).ToListAsync();
            var product = await _productServices.GetAllProduct();
            var listJoin = from productdetail in productlist
                           join cart in list on productdetail.ID equals cart.IDProductDetail
                           join b in product on productdetail.IDProduct equals b.ID
                           where cart.Quantity > 0
                           select new CartDetailViewModel()
                           {
                               IDProductDetail = productdetail.ID,
                               Quantity = cart.Quantity,
                               Price = productdetail.Price,
                               TotalPriceEachItem = productdetail.Price * cart.Quantity,
                               TotalPriceAll = 0,
                               Image = productdetail.DefaultImage,
                               ProductName = b.Name,
                           };

            var dataReturn = listJoin.Adapt<List<CartDetailViewModel>>();

            if (!(dataReturn?.Count > 0)) return new List<CartDetailViewModel>();

            var total = dataReturn.Sum(price => (double)price.TotalPriceEachItem);

            foreach (var price in dataReturn)
            {
                price.TotalPriceAll = (int)total;
            }

            return dataReturn;
        }

        public async Task<bool> Update(UpdateCartDetailViewModel model)
        {
            var data = _dbContext.CartDetails.Find(model.ID);
            if (data == null)
            {
                return false;
            }
            data.Quantity = model.Quantity;
            _dbContext.CartDetails.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return true;
        }
    }
}