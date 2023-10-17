using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Role;
using ShoesShop.DAL.ApplicationDbContext;

namespace ShoesShop.BLL.Services.Implements
{
    public class RoleServices : IRoleServices
    {
        private WebDbContext _dbContext;

        public RoleServices(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddRole(AddRoleViewModel model)
        {
            try
            {
                var data = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == model.ID);
                if (data != null)
                {
                    return false;
                }
                data.CreateDate = DateTime.Now;
                await _dbContext.Roles.AddAsync(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteRole(Guid id)
        {
            try
            {
                var data = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Status > 0 && x.ID == id);
                if (data != null)
                {
                    return false;
                }
                data.Status = 0;
                _dbContext.Roles.Update(data);
                await _dbContext.SaveChangesAsync(new CancellationToken());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<RoleViewModel>> GetAllRole()
        {
            var data = await _dbContext.Roles.Where(s => s.Status > 0).OrderByDescending(a => a.CreateDate).ToListAsync();
            return data.Adapt<List<RoleViewModel>>();
        }

        public async Task<RoleViewModel> GetRoleById(Guid id)
        {
            var data = await _dbContext.Roles.FirstOrDefaultAsync(x => x.ID == id);
            return data == null ? new RoleViewModel() : data.Adapt<RoleViewModel>();
        }

        public async Task<bool> UpdateRole(UpdateRoleViewModel model)
        {
            var data = _dbContext.Roles.FirstOrDefault(x => x.ID == model.ID);
            if (data == null)
            {
                return false;
            }
            data.RoleName = model.RoleName;
            data.Description = model.Description;
            data.Status = model.Status;
            data.LastModifiedDate = DateTime.Now;
            _dbContext.Roles.Update(data);
            await _dbContext.SaveChangesAsync(new CancellationToken());
            return true;
        }
    }
}