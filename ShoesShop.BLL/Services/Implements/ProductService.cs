using ShoesShop.BLL.Services.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Persistence;
using ShoesShop.BLL.ViewModels.Images;
using ShoesShop.BLL.ViewModels.Product;
using ShoesShop.BLL.ViewModels.Property;
using ShoesShop.DAL.Entities;
using ShoesShop.DAL.Enums;
using ShoesShop.DAL.Helpers;

namespace ShoesShop.BLL.Services.Implements;

public class ProductService : IProductService
{
    private readonly WebDbContext _dbContext;

    public ProductService(WebDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductDetailModel>> GetListProduct()
    {
        var products = await _dbContext.Products
            .Where(s => !s.IsDeleted)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();

        var statuses = await _dbContext.Status
            .Where(s => !s.IsDeleted
                        && s.Type.Equals(StatusType.Product.ReadDescription())
                        && s.Code.Equals(ProductStatus.AvailableCode.ReadDescription()))
            .ToListAsync();
        var brands = await _dbContext.Brands.Where(s => !s.IsDeleted).ToListAsync();
        var categories = await _dbContext.Categories.Where(s => !s.IsDeleted).ToListAsync();
        var colors = await _dbContext.Colors.Where(s => !s.IsDeleted).ToListAsync();
        var sizes = await _dbContext.Sizes.Where(s => !s.IsDeleted).ToListAsync();
        var materials = await _dbContext.Materials.Where(s => !s.IsDeleted).ToListAsync();

        var listJoin = from product in products
                       join category in categories on product.CategoryId equals category.Id
                       join brand in brands on product.BrandId equals brand.Id
                       join color in colors on product.ColorId equals color.Id
                       join size in sizes on product.SizeId equals size.Id
                       join material in materials on product.MaterialId equals material.Id
                       join status in statuses on product.StatusId equals status.Id
                       where !category.IsDeleted && !brand.IsDeleted && !status.IsDeleted && !product.IsDeleted && !color.IsDeleted && !size.IsDeleted && !material.IsDeleted
                       select new
                       {
                           Id = product.Id,
                           IsDeleted = product.IsDeleted,
                           UpdatedAt = product.UpdatedAt,
                           UpdatedBy = product.UpdatedBy,
                           CreatedAt = product.CreatedAt,
                           CreatedBy = product.CreatedBy,
                           Name = product.Name,
                           Description = product.Description,
                           Price = product.Price,
                           Discount = product.Discount,
                           Currency = product.Currency,
                           OriginLinkDetail = product.OriginLinkDetail,
                           Url = product.Url,
                           Stock = product.Stock,
                           Brand = brand.Name,
                           Category = category.Name,
                           Color = color.Name,
                           Size = size.Name,
                           Material = material.Name,                      
                           DefaultImage = product.DefaultImage
                       };

        var finalData = listJoin.Adapt<List<ProductDetailModel>>().ToList();

        return finalData;
    }

    public async Task<bool> AddNew(AddNewProductModel model)
    {
        try
        {
            var product = model.Adapt<Product>();
            product.StatusId = _dbContext.Status
                .First(s => !s.IsDeleted
                            && s.Type.Equals(StatusType.Product.ReadDescription())
                            && s.Code.Equals(ProductStatus.AvailableCode.ReadDescription())).Id;
            product.Stock = 0;
            product.Url = model.Name.VietnameseToNormalString();
            product.OriginLinkDetail = model.Name.ToStringCode();
            product.DefaultImage = model.ListImage.First().LocalLinkImage;

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync(new CancellationToken());

            if (model.Properties != null)
            {
                await _dbContext.Properties.AddRangeAsync(model.Properties.Adapt<List<Property>>());
                await _dbContext.SaveChangesAsync(new CancellationToken());
            }

            await _dbContext.Images.AddRangeAsync(model.ListImage.Adapt<List<Image>>());
            await _dbContext.SaveChangesAsync(new CancellationToken());

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Delete(Guid id)
    {
        try
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == id);

            if (product == null) return false;

            product.IsDeleted = true;

            _dbContext.Products.Update(product);

            await _dbContext.SaveChangesAsync(new CancellationToken());

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<ProductDetailModel> Detail(string id)
    {
        var productId = Guid.Parse(id);

        var product = await _dbContext.Products
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == productId);

        if (product == null) return new ProductDetailModel();

        var brand = await _dbContext.Brands
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == product.BrandId);

        if (brand == null) return new ProductDetailModel();

        var category = await _dbContext.Categories
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == product.CategoryId);

        if (category == null) return new ProductDetailModel();

        var color = await _dbContext.Colors
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == product.ColorId);

        if (color == null) return new ProductDetailModel();

        var size = await _dbContext.Sizes
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == product.SizeId);

        if (size == null) return new ProductDetailModel();

        var material = await _dbContext.Materials
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == product.MaterialId);

        if (material == null) return new ProductDetailModel();

        var properties = await _dbContext.Properties
            .Where(s => !s.IsDeleted && s.ProductId == productId)
            .ToListAsync();

        var images = await _dbContext.Images
            .Where(s => !s.IsDeleted && s.ProductId == productId)
            .ToListAsync();

        var finalData = product.Adapt<ProductDetailModel>();
        finalData.Brand = brand.Name;
        finalData.Category = category.Name;
        finalData.Color = color.Name;
        finalData.Size = size.Name;
        finalData.Material = material.Name;
        finalData.Images = images.Adapt<List<ImageDetailModel>>();
        finalData.Properties = properties.Adapt<List<PropertyDetailModel>>();

        return finalData;
    }

    public async Task<List<ProductDetailModel>> GetListSearch(string search)
    {
        var products = await _dbContext.Products
            .Where(s => !s.IsDeleted)
            .ToListAsync();
        var statuses = await _dbContext.Status
            .Where(s => !s.IsDeleted
                        && s.Type.Equals(StatusType.Product.ReadDescription())
                        && s.Code.Equals(ProductStatus.AvailableCode.ReadDescription()))
            .ToListAsync();
        var brands = await _dbContext.Brands.Where(s => !s.IsDeleted).ToListAsync();
        var categories = await _dbContext.Categories.Where(s => !s.IsDeleted).ToListAsync();
        var colors = await _dbContext.Colors.Where(s => !s.IsDeleted).ToListAsync();
        var sizes = await _dbContext.Sizes.Where(s => !s.IsDeleted).ToListAsync();
        var materials = await _dbContext.Materials.Where(s => !s.IsDeleted).ToListAsync();

        var listJoin = from product in products
                       join category in categories on product.CategoryId equals category.Id
                       join brand in brands on product.BrandId equals brand.Id
                       join color in colors on product.ColorId equals color.Id
                       join size in sizes on product.SizeId equals size.Id
                       join material in materials on product.MaterialId equals material.Id
                       join status in statuses on product.StatusId equals status.Id
                       where !category.IsDeleted && !brand.IsDeleted && !status.IsDeleted && !product.IsDeleted && !color.IsDeleted && !size.IsDeleted && !material.IsDeleted
                       select new
                       {
                           Id = product.Id,
                           IsDeleted = product.IsDeleted,
                           UpdatedAt = product.UpdatedAt,
                           UpdatedBy = product.UpdatedBy,
                           CreatedAt = product.CreatedAt,
                           CreatedBy = product.CreatedBy,
                           Name = product.Name,
                           Description = product.Description,
                           Price = product.Price,
                           Discount = product.Discount,
                           Currency = product.Currency,
                           OriginLinkDetail = product.OriginLinkDetail,
                           Url = product.Url,
                           Stock = product.Stock,
                           Brand = brand.Name,
                           Category = category.Name,
                           Color = color.Name,
                           Size = size.Name,
                           Material = material.Name,
                           DefaultImage = product.DefaultImage,
                           CategoryCode = category.Code,
                           BrandCode = brand.Code,
                           ColorCode = color.Code,
                           SizeCode = size.Code,
                           MaterialCode = material.Code,
                       };

        var finalData = listJoin.Adapt<List<ProductDetailModel>>().ToList();

        if (string.IsNullOrEmpty(search))
        {
            return finalData;
        }
        else
        {
            return finalData
                .Where(s => s.Name.ToLower().Contains(search.ToLower()))
                .ToList();
        }
    }

    public async Task<List<ProductDetailModel>> GetListCategoryOrBrand(string type, string typeValue)
    {
        var finalData = await GetListSearch("");

        if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(typeValue))
        {
            return finalData;
        }
        else
        {
            return type.ToLower() switch
            {
                "category" => finalData.Where(s =>
                    string.Equals(s.CategoryCode, typeValue, StringComparison.CurrentCultureIgnoreCase)).ToList(),
                "brand" => finalData.Where(s =>
                    string.Equals(s.BrandCode, typeValue, StringComparison.CurrentCultureIgnoreCase)).ToList(),
                "color" => finalData.Where(s =>
                string.Equals(s.ColorCode, typeValue, StringComparison.CurrentCultureIgnoreCase)).ToList(),
                "size" => finalData.Where(s =>
                    string.Equals(s.SizeCode, typeValue, StringComparison.CurrentCultureIgnoreCase)).ToList(),
                "material" => finalData.Where(s =>
                string.Equals(s.MaterialCode, typeValue, StringComparison.CurrentCultureIgnoreCase)).ToList(),
                _ => finalData
            };
        }
    }

    public List<ProductDetailModel> GetListRangePrice(List<ProductDetailModel> list, decimal? min, decimal? max)
    {
        return list.Where(s => s.Price >= min && s.Price <= max)
            .ToList();
    }

    public async Task<bool> Update(UpdateProductModel model)
    {
        try
        {
            var productDetail = await _dbContext.Products.FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == model.Id);
            if (productDetail == null) return false;

            if (model.ListImage?.Count > 0)
            {
                var currentImages = await _dbContext.Images.Where(s => s.ProductId == model.Id).ToListAsync();
                if (currentImages?.Count > 0)
                {
                    foreach (var image in currentImages)
                    {
                        image.IsDeleted = true;
                    }

                    _dbContext.Images.UpdateRange(currentImages);
                    await _dbContext.SaveChangesAsync(new CancellationToken());
                }

                productDetail.DefaultImage = model.ListImage.First().LocalLinkImage;
                await _dbContext.Images.AddRangeAsync(model.ListImage.Adapt<List<Image>>());
                await _dbContext.SaveChangesAsync(new CancellationToken());
            }

            productDetail.Currency = model.Currency;
            productDetail.Name = model.Name;
            productDetail.Description = model.Description;
            productDetail.Price = model.Price;
            productDetail.Discount = model.Discount;
            productDetail.Currency = model.Currency;
            productDetail.BrandId = model.BrandId;
            productDetail.CategoryId = model.CategoryId;
            productDetail.ColorId = model.ColorId;
            productDetail.SizeId = model.SizeId;
            productDetail.MaterialId = model.MaterialId;

            _dbContext.Products.Update(productDetail);
            await _dbContext.SaveChangesAsync(new CancellationToken());

            var currentProperties = await _dbContext.Properties.Where(s => s.ProductId == model.Id && !s.IsDeleted)
                .ToListAsync();
            if (currentProperties?.Count > 0)
            {
                foreach (var property in currentProperties)
                {
                    property.IsDeleted = true;
                }

                _dbContext.Properties.UpdateRange(currentProperties);
                await _dbContext.SaveChangesAsync(new CancellationToken());
            }

            if (model.Properties == null) return true;

            await _dbContext.Properties.AddRangeAsync(model.Properties.Adapt<List<Property>>());
            await _dbContext.SaveChangesAsync(new CancellationToken());

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<ProductDetailModel> DetailByUrl(string url)
    {
        var product = await _dbContext.Products
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Url == url);

        if (product == null) return new ProductDetailModel();

        var brand = await _dbContext.Brands
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == product.BrandId);

        if (brand == null) return new ProductDetailModel();

        var category = await _dbContext.Categories
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == product.CategoryId);

        if (category == null) return new ProductDetailModel();

        var color = await _dbContext.Colors
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == product.ColorId);

        if (color == null) return new ProductDetailModel();

        var size = await _dbContext.Sizes
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == product.SizeId);

        if (size == null) return new ProductDetailModel();

        var material = await _dbContext.Materials
            .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == product.MaterialId);

        if (material == null) return new ProductDetailModel();

        var properties = await _dbContext.Properties
            .Where(s => !s.IsDeleted && s.ProductId == product.Id)
            .ToListAsync();

        var images = await _dbContext.Images
            .Where(s => !s.IsDeleted && s.ProductId == product.Id)
            .ToListAsync();

        var finalData = product.Adapt<ProductDetailModel>();
        finalData.Brand = brand.Name;
        finalData.Category = category.Name;
        finalData.Color = color.Name;
        finalData.Size = size.Name;
        finalData.Material = material.Name;
        finalData.Images = images.Adapt<List<ImageDetailModel>>();
        finalData.Properties = properties.Adapt<List<PropertyDetailModel>>();

        return finalData;
    }
}