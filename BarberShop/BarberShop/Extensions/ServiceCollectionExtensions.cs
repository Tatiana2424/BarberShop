using BarberShop.DAL.Persistence;
using BarberShop.DAL.Repositories.Interfaces.Base;
using BarberShop.DAL.Repositories.Realizations.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BarberShop.BLL.Interfaces.Logging;
using BarberShop.BLL.Services.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using BarberShop.BLL.Services;
using BarberShop.BLL.Interfaces;
using BarberShop.DAL.Repositories.Interfaces;
using BarberShop.DAL.Repositories.Realizations;

namespace BarberShop.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<BLL.Interfaces.IAuthenticationService, BLL.Services.AuthenticationService>();
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddRepositoryServices();
        
        var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
        services.AddAutoMapper(currentAssemblies);
        services.AddMediatR(currentAssemblies);

        //services.AddScoped(typeof(IFact), typeof(Fact));
        services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));
        //services.AddScoped<IRequestHandler<GetCategoryByIdQuery, Result<CategoryDTO>>, GetCategoryByIdHandler>();
    }
    public static void AddApplicationServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<BarberShopDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("BarberShopDB"), opt =>
            {
                opt.MigrationsAssembly(typeof(BarberShopDbContext).Assembly.GetName().Name);
                opt.MigrationsHistoryTable("__EFMigrationsHistory", schema: "entity_framework");
            });
        });

        services.AddCors(opt =>
        {
            opt.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.SetPreflightMaxAge(TimeSpan.FromDays(1));
            });
        });

        services.AddControllers();
    }

    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "MyAppCookie";
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/Forbidden";
            });
        services.Configure<CookiePolicyOptions>(options =>
        {
            options.MinimumSameSitePolicy = SameSiteMode.Strict;
            options.HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always;
            options.Secure = CookieSecurePolicy.SameAsRequest;
        });

        services.Configure<CookieAuthenticationOptions>(options =>
        {
            options.Cookie.Name = configuration.GetValue<string>("CookieSettings:CookieName");
            options.ExpireTimeSpan = TimeSpan.FromMinutes(configuration.GetValue<int>("CookieSettings:ExpirationTimeInMinutes"));
            options.SlidingExpiration = configuration.GetValue<bool>("CookieSettings:SlidingExpiration");
        });
    
    //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    //.AddCookie(options =>
    //{
    //    options.Events.OnValidatePrincipal = async context =>
    //    {
    //        var expiresUtc = context.Properties.GetTokenValue("expires_at");
    //        if (DateTimeOffset.TryParse(expiresUtc, out var expires) &&
    //            expires < DateTimeOffset.UtcNow.AddMinutes(10))
    //        {
    //            var refreshToken = context.Properties.GetTokenValue("refresh_token");
    //            var newToken = await new TokenService().RefreshToken(refreshToken); // Reference TokenService
    //            context.Properties.UpdateTokenValue("access_token", newToken);
    //            context.Properties.UpdateTokenValue("expires_at", GetExpirationTime().ToString("o"));
    //            context.ShouldRenew = true;
    //        }
    //    };
    //});
    }

}
