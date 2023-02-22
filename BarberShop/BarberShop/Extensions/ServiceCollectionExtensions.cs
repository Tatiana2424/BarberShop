using BarberShop.DAL.Persistence;
using BarberShop.DAL.Repositories.Interfaces.Base;
using BarberShop.DAL.Repositories.Realizations.Base;
using Hangfire;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddRepositoryServices();

        //var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
        //services.AddAutoMapper(currentAssemblies);
        //services.AddMediatR(currentAssemblies);

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

        //services.AddHangfire(config =>
        //{
        //    config.UseSqlServerStorage(configuration.GetConnectionString("BarberShopDB"));
        //});

        //services.AddHangfireServer();

        services.AddControllers();
    }
}
