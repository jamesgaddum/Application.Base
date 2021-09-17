using Flatties.Matching.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flatties.Matching.Persistence
{
    public static class DependencyInjection
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FlattiesDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddTransient<IFlattiesDbContext>(provider => provider.GetService<FlattiesDbContext>());

            return services;
        }
    }
}
