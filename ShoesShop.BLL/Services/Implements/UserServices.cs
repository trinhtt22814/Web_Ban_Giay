using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.User;
using ShoesShop.DAL.ApplicationDbContext;

namespace ShoesShop.BLL.Services.Implements
{
    public class UserServices : IUserServices
    {
        private WebDbContext _dbContext;

        public UserServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddUser(AddUserViewModel model)
        {
            try
            {
                var data = await _dbContext.Users.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == model.ID);
                if (data != null)
                {
                    return false;
                }
                await _dbContext.Users.AddAsync(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            try
            {
                var data = await _dbContext.Users.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == id);
                if (data != null)
                {
                    return false;
                }
                data.Status = 0;
                _dbContext.Users.Update(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<UserViewModel>> GetAllUser()
        {
            var data = await _dbContext.Users.Where(s => s.Status > 0).OrderByDescending(a => a.CreatedDate).ToListAsync();
            return data.Adapt<List<UserViewModel>>();
        }

        public async Task<UserViewModel> GetUserById(Guid id)
        {
            var data = await _dbContext.Users.FirstOrDefaultAsync(x => x.ID == id);
            return data == null ? new UserViewModel() : data.Adapt<UserViewModel>();
        }

        public async Task<bool> UpdateUser(UpdateUserViewModel model)
        {
            var data = _dbContext.Users.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                return false;
            }

            data.Password = model.Password;
            data.FullName = model.FullName;
            data.DateOfBirth = model.DateOfBirth;
            data.Address = model.Address;
            data.Email = model.Email;
            data.PhoneNumber = model.PhoneNumber;
            data.Gender = model.Gender;
            data.Avatar = model.Avatar;
            data.UpdatedBy = model.UpdatedBy;
            data.LastModifiedDate = DateTime.Now;
            data.Status = model.Status;
            _dbContext.Users.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return true;
        }
    }
}