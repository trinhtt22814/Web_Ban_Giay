 
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoesShop.BLL.Common.ViewModels;
using ShoesShop.BLL.Persistence;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.BLL.ViewModels.Brands;
using ShoesShop.BLL.ViewModels.Categories;
using ShoesShop.BLL.ViewModels.Color;
using ShoesShop.BLL.ViewModels.Material;
using ShoesShop.BLL.ViewModels.Promotion;
using ShoesShop.BLL.ViewModels.Size;
using ShoesShop.BLL.ViewModels.Status;
using ShoesShop.DAL.Constants;
using ShoesShop.DAL.Entities;
using ShoesShop.DAL.Enums;
using ShoesShop.DAL.Helpers;

namespace ShoesShop.BLL.Services.Implements;

public class InitDataService : IInitDataService
{
    private readonly RoleManager<AppRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly WebDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public InitDataService(
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager,
        WebDbContext dbContext,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public async Task InitData()
    {
        await InitRoles();
        await InitUsers();
        await InitStatus();
        await InitBrands();
        await InitCategories();
        await InitColors();
        await InitMaterials();
        await InitSizes();
        await InitPromotions();
    }

    private async Task InitRoles()
    {
        foreach (var role in SecurityRoles.Roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new AppRole
                {
                    Name = role,
                    NormalizedName = role.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Description = $"Role for {role}"
                });
            }
        }
    }

    private async Task InitUsers()
    {
        #region data for init

        List<UserInitModel> data = new()
        {
            // full role
            new UserInitModel
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                Email = "admin@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                Roles = SecurityRoles.Roles.ToList(),
                FullName = "Admin",
                IsActive = true,
                IsDeleted = false,
                CreatedAt = DateTime.Now,
                CreatedBy = AppConst.Domain,
                SocialJson = "[]",
                LastLoginJson = "{}",
                Picture = AppConst.DefaultAvatar,
                NickName = Guid.NewGuid().ToString()
            },
            // ignore admin
            new UserInitModel
            {
                Id = Guid.NewGuid(),
                UserName = "user",
                Email = "user@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                Roles = SecurityRoles.Roles.Where(s => !s.Equals(SecurityRoles.Admin)
                                                       && !s.Equals(SecurityRoles.Manager)).ToList(),
                FullName = "User",
                IsActive = true,
                IsDeleted = false,
                CreatedAt = DateTime.Now,
                CreatedBy = AppConst.Domain,
                SocialJson = "[]",
                LastLoginJson = "{}",
                Picture = AppConst.DefaultAvatar,
                NickName = Guid.NewGuid().ToString()
            },
            new UserInitModel
            {
                Id = Guid.NewGuid(),
                UserName = "manager",
                Email = "manager@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                Roles = SecurityRoles.Roles.Where(s => !s.Equals(SecurityRoles.Admin)).ToList(),
                FullName = "Manager",
                IsActive = true,
                IsDeleted = false,
                CreatedAt = DateTime.Now,
                CreatedBy = AppConst.Domain,
                SocialJson = "[]",
                LastLoginJson = "{}",
                Picture = AppConst.DefaultAvatar,
                NickName = Guid.NewGuid().ToString()
            }
        };

        #endregion data for init

        foreach (var item in data)
        {
            var user = await _userManager.FindByNameAsync(item.UserName);

            if (user == null)
            {
                await _userManager.CreateAsync(item.Adapt<AppUser>(), _configuration["DefaultPassword"]);
            }

            var userExist = await _userManager.FindByNameAsync(item.UserName);

            if (userExist == null)
            {
                continue;
            }

            await _userManager.RemoveFromRolesAsync(userExist, SecurityRoles.Roles);
            await _userManager.AddToRolesAsync(userExist, SecurityRoles.Roles);
        }
    }

    private async Task InitStatus()
    {
        #region data for status

        var data = new List<AddNewStatusModel>()
        {
            new AddNewStatusModel()
            {
                Id = Guid.NewGuid(),
                Type = StatusType.Order.ReadDescription(),
                Code = OrderStatus.ReceivedCode.ReadDescription(),
                Display = AppVersion.IsEnglishVersion
                    ? OrderStatus.ReceivedDisplayEN.ReadDescription()
                    : OrderStatus.ReceivedDisplayVN.ReadDescription(),
            },
            new AddNewStatusModel()
            {
                Id = Guid.NewGuid(),
                Type = StatusType.Order.ReadDescription(),
                Code = OrderStatus.CancelCode.ReadDescription(),
                Display = AppVersion.IsEnglishVersion
                    ? OrderStatus.CancelDisplayEN.ReadDescription()
                    : OrderStatus.CancelDisplayVN.ReadDescription(),
            },
            new AddNewStatusModel()
            {
                Id = Guid.NewGuid(),
                Type = StatusType.Order.ReadDescription(),
                Code = OrderStatus.RejectCode.ReadDescription(),
                Display = AppVersion.IsEnglishVersion
                    ? OrderStatus.RejectDisplayEN.ReadDescription()
                    : OrderStatus.RejectDisplayVN.ReadDescription(),
            },
            new AddNewStatusModel()
            {
                Id = Guid.NewGuid(),
                Type = StatusType.Order.ReadDescription(),
                Code = OrderStatus.AwaitingShipCode.ReadDescription(),
                Display = AppVersion.IsEnglishVersion
                    ? OrderStatus.AwaitingShipDisplayEN.ReadDescription()
                    : OrderStatus.AwaitingShipDisplayVN.ReadDescription(),
            },
            new AddNewStatusModel()
            {
                Id = Guid.NewGuid(),
                Type = StatusType.Order.ReadDescription(),
                Code = OrderStatus.ShippingCode.ReadDescription(),
                Display = AppVersion.IsEnglishVersion
                    ? OrderStatus.ShippingDisplayEN.ReadDescription()
                    : OrderStatus.ShippingDisplayVN.ReadDescription(),
            },
            new AddNewStatusModel()
            {
                Id = Guid.NewGuid(),
                Type = StatusType.Product.ReadDescription(),
                Code = ProductStatus.AvailableCode.ReadDescription(),
                Display = AppVersion.IsEnglishVersion
                    ? ProductStatus.AvailableDisplayEN.ReadDescription()
                    : ProductStatus.AvailableDisplayVN.ReadDescription(),
            },
            new AddNewStatusModel()
            {
                Id = Guid.NewGuid(),
                Type = StatusType.Product.ReadDescription(),
                Code = ProductStatus.NotAvailableCode.ReadDescription(),
                Display = AppVersion.IsEnglishVersion
                    ? ProductStatus.NotAvailableDisplayEN.ReadDescription()
                    : ProductStatus.NotAvailableDisplayVN.ReadDescription(),
            },
            new AddNewStatusModel()
            {
                Id = Guid.NewGuid(),
                Type = StatusType.Payment.ReadDescription(),
                Code = PaymentStatus.PaidCode.ReadDescription(),
                Display = AppVersion.IsEnglishVersion
                    ? PaymentStatus.PaidDisplayEN.ReadDescription()
                    : PaymentStatus.PaidDisplayVN.ReadDescription(),
            },
            new AddNewStatusModel()
            {
                Id = Guid.NewGuid(),
                Type = StatusType.Payment.ReadDescription(),
                Code = PaymentStatus.WaitingPayCode.ReadDescription(),
                Display = AppVersion.IsEnglishVersion
                    ? PaymentStatus.WaitingPayDisplayEN.ReadDescription()
                    : PaymentStatus.WaitingPayDisplayVN.ReadDescription(),
            }
        };

        #endregion data for status

        var dataAdapt = data.Adapt<List<Status>>();
        var dataFinal = new List<Status>();

        foreach (var item in dataAdapt)
        {
            var exists = await _dbContext.Status.FirstOrDefaultAsync(s => s.Display == item.Display);

            if (exists == null)
            {
                dataFinal.Add(item);
            }
        }

        if (dataFinal?.Count > 0)
        {
            await _dbContext.Status.AddRangeAsync(dataFinal);
            await _dbContext.SaveChangesAsync(new CancellationToken());
        }
    }

    private async Task InitBrands()
    {
        #region data for brands

        var data = new List<AddNewBrandModel>()
        {
            new AddNewBrandModel()
            {
                Code = "nike",
                Name = "Nike",
            },
            new AddNewBrandModel()
            {
                Code = "converse",
                Name = "Converse",
            },
            new AddNewBrandModel()
            {
                Code = "adidas",
                Name = "Adidas",
            },
            new AddNewBrandModel()
            {
                Code = "puma",
                Name = "Puma",
            }
        };

        #endregion data for brands

        var dataAdapt = data.Adapt<List<Brand>>();
        var dataFinal = new List<Brand>();

        foreach (var item in dataAdapt)
        {
            var exists = await _dbContext.Brands.FirstOrDefaultAsync(s => s.Name == item.Name);

            if (exists == null)
            {
                dataFinal.Add(item);
            }
        }

        if (dataFinal?.Count > 0)
        {
            await _dbContext.Brands.AddRangeAsync(dataFinal);
            await _dbContext.SaveChangesAsync(new CancellationToken());
        }
    }

    private async Task InitCategories()
    {
        #region data for categories

        var data = new List<AddNewCategoryModel>()
        {
            new AddNewCategoryModel()
            {
                Code = "giay-luoi",
                Name = "Giày Lười",
            },
            new AddNewCategoryModel()
            {
                Code = "sport",
                Name = "Giày Thể thao",
            },
            new AddNewCategoryModel()
            {
                Code = "sneaker ",
                Name = "Giày Sneaker ",
            },
            new AddNewCategoryModel()
            {
                Code = "giay-da",
                Name = "Giày Da",
            }
        };

        #endregion data for categories

        var dataAdapt = data.Adapt<List<Category>>();
        var dataFinal = new List<Category>();

        foreach (var item in dataAdapt)
        {
            var exists = await _dbContext.Categories.FirstOrDefaultAsync(s => s.Name == item.Name);

            if (exists == null)
            {
                dataFinal.Add(item);
            }
        }

        if (dataFinal?.Count > 0)
        {
            await _dbContext.Categories.AddRangeAsync(dataFinal);
            await _dbContext.SaveChangesAsync(new CancellationToken());
        }
    }
    private async Task InitColors()
    {
        #region data for colors

        var data = new List<AddNewColorModel>()
        {
            new AddNewColorModel()
            {
                Code = "mau-trang",
                Name = "Màu Trắng",
            },
            new AddNewColorModel()
            {
                Code = "mau-den",
                Name = "Màu Đen",
            },
            new AddNewColorModel()
            {
                Code = "mau-nau",
                Name = "Màu Nâu",
            },
            new AddNewColorModel()
            {
                Code = "mau-do",
                Name = "Màu Đỏ",
            }
        };

        #endregion data for colors

        var dataAdapt = data.Adapt<List<Color>>();
        var dataFinal = new List<Color>();

        foreach (var item in dataAdapt)
        {
            var exists = await _dbContext.Colors.FirstOrDefaultAsync(s => s.Name == item.Name);

            if (exists == null)
            {
                dataFinal.Add(item);
            }
        }

        if (dataFinal?.Count > 0)
        {
            await _dbContext.Colors.AddRangeAsync(dataFinal);
            await _dbContext.SaveChangesAsync(new CancellationToken());
        }
    }
    private async Task InitMaterials()
    {
        #region data for materials

        var data = new List<AddNewMaterialModel>()
        {
            new AddNewMaterialModel()
            {
                Code = "da",
                Name = "Da",
            },
            new AddNewMaterialModel()
            {
                Code = "theu",
                Name = "Thêu",
            },
            new AddNewMaterialModel()
            {
                Code = "tong-hop",
                Name = "Tổng Hợp",
            },
            new AddNewMaterialModel()
            {
                Code = "cao-su",
                Name = "Cao su",
            }
        };

        #endregion data for materials

        var dataAdapt = data.Adapt<List<Material>>();
        var dataFinal = new List<Material>();

        foreach (var item in dataAdapt)
        {
            var exists = await _dbContext.Materials.FirstOrDefaultAsync(s => s.Name == item.Name);

            if (exists == null)
            {
                dataFinal.Add(item);
            }
        }

        if (dataFinal?.Count > 0)
        {
            await _dbContext.Materials.AddRangeAsync(dataFinal);
            await _dbContext.SaveChangesAsync(new CancellationToken());
        }
    }
    private async Task InitSizes()
    {
        #region data for sizes

        var data = new List<AddNewSizeModel>()
        {
            new AddNewSizeModel()
            {
                Code = "size-37",
                Name = "Size 37",
            },
            new AddNewSizeModel()
            {
                Code = "size-38-39",
                Name = "Size 38-39",
            },
            new AddNewSizeModel()
            {
                Code = "size-40-41",
                Name = "Size 40-41",
            },
            new AddNewSizeModel()
            {
                Code = "size-42",
                Name = "Size 42",
            }
        };

        #endregion data for sizes

        var dataAdapt = data.Adapt<List<Size>>();
        var dataFinal = new List<Size>();

        foreach (var item in dataAdapt)
        {
            var exists = await _dbContext.Sizes.FirstOrDefaultAsync(s => s.Name == item.Name);

            if (exists == null)
            {
                dataFinal.Add(item);
            }
        }

        if (dataFinal?.Count > 0)
        {
            await _dbContext.Sizes.AddRangeAsync(dataFinal);
            await _dbContext.SaveChangesAsync(new CancellationToken());
        }
    }

    private async Task InitPromotions()
    {
        #region data for promotions

        var data = new List<AddNewPromotionModel>()
        {
            new AddNewPromotionModel()
            {
                Code = "PRO00001",
                DiscountPercent = 10,
            },
            new AddNewPromotionModel()
            {
                Code = "PRO00002",
                DiscountPercent = 12,
            },
            new AddNewPromotionModel()
            {
                Code = "PRO00003",
                DiscountPercent = 15,
            },
            new AddNewPromotionModel()
            {
                Code = "PRO00004",
                DiscountPercent = 20,
            },
        };

        #endregion data for promotions

        var dataAdapt = data.Adapt<List<Promotion>>();
        var dataFinal = new List<Promotion>();

        foreach (var item in dataAdapt)
        {
            var exists = await _dbContext.Promotions.FirstOrDefaultAsync(s => s.Code == item.Code);

            if (exists == null)
            {
                dataFinal.Add(item);
            }
        }

        if (dataFinal?.Count > 0)
        {
            await _dbContext.Promotions.AddRangeAsync(dataFinal);
            await _dbContext.SaveChangesAsync(new CancellationToken());
        }
    }
}