using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.DAL.ApplicationDbContext;
using ShoesShop.DAL.Entities;

namespace ShoesShop.BLL.Services.Implements
{
    public class CartServices : ICartServices
    {
        private WebDbContext _dbContext;

        public CartServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(Cart model)
        {
            try
            {
                await _dbContext.Carts.AddAsync(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid userId)
        {
            try
            {
                var data = await _dbContext.Carts.FindAsync(userId);
                _dbContext.Carts.Remove(data);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Cart> GetByUser(Guid userId)
        {
            return await _dbContext.Carts.FindAsync(userId);
        }
    }
}