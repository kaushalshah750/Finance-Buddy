using Microsoft.Extensions.DependencyInjection;
using Orien.FinanceBuddy.Business.Services;
using Orien.FinanceBuddy.Business.Services.Implementation;

namespace Orien.FinanceBuddy.Business.Microsoft.Extensions.DependencyInjection
{
    public static class BusinessExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
