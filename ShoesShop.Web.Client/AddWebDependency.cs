using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace ShoesShop.Web.Client
{
    public static class AddWebDependency
    {
        public static IServiceCollection WebDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSignalR();

            services.AddRazorPages()
                .AddRazorRuntimeCompilation();

            services.AddControllersWithViews();

            services.AddHttpContextAccessor();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(2);
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            

            //ISS
            services.Configure<IISServerOptions>(options => { options.MaxRequestBodySize = int.MaxValue; });
            //Kestrel
            services.Configure<KestrelServerOptions>(options => { options.Limits.MaxRequestBodySize = int.MaxValue; });
            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });

            return services;
        }
    }
}
