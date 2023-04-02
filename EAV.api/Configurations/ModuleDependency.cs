using Microsoft.EntityFrameworkCore;

namespace EAV.api.Configurations
{
    public static class ModuleDependency
    {
        public static IServiceCollection AddServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MyDbContext>(options => options.UseNpgsql(connectionString));

            return services;
        }
    }
}
