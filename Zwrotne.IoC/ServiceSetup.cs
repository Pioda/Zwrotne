using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zwrotne.Infrastructure;

namespace Zwrotne.IoC;

public static class ServiceSetup
{
    public static IServiceCollection Setup(this IServiceCollection serviceProvider, IConfiguration configuration)
    {
        serviceProvider.AddDbContext<ZwrotneDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        return serviceProvider;
    }
}
