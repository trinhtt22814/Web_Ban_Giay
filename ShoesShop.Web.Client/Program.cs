using BLL.Services.Interfaces;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using ShoesShop.BLL.Persistence;
using ShoesShop.BLL.Services.Implements;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.DAL.Constants;
using ShoesShop.Web.Client;
using ShoesShop.Web.Client.WebHub;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<WebDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.WebDependency(builder.Configuration);

builder.Services.AddScoped<ICommonService, CommonService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IInitDataService, InitDataService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IVNPayService, VNPayService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPromotionService, PromotionService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IColorService, ColorServices>();
builder.Services.AddScoped<IMaterialService, MaterialServices>();
builder.Services.AddScoped<ISizeService, SizeServices>();

var app = builder.Build();

app.UseStatusCodePages(context =>
{
    var response = context.HttpContext.Response;

    switch (response.StatusCode)
    {
        case (int)HttpStatusCode.NotFound:
            response.Redirect("/Common/NotFoundPage");
            break;

        case (int)HttpStatusCode.Unauthorized:
            response.Redirect("/#login");
            break;

        case (int)HttpStatusCode.Forbidden:
            response.Redirect("/Common/AccessDenied");
            break;
    }

    return Task.CompletedTask;
});

// Configure the HTTP request pipeline.
app.UseExceptionHandler("/Common/Error");
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();

app.UseSession();

app.Use(async (context, next) =>
{
    var jwtToken = context.Session.GetString(AppConst.SessionJwtKey);
    // var jwtToken = context.Request.GetCookie(SystemConst.AppSecure);
    if (!string.IsNullOrEmpty(jwtToken))
        context.Request.Headers.Add("Authorization", "Bearer " + jwtToken);
    await next();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedProto
});

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}");

    endpoints.MapHub<WebHub>("/realtime");
});

app.Run();