using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderService.DbContext.DatabaseInitialization;

namespace OrderService.DbContext
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("OrderService"));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<DatabaseInitializer>();
            return services;
        }
    }
}
