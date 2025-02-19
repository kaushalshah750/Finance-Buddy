using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Orien.FinanceBuddy.Data.Microsoft.Extensions.DependencyInjection
{
    public static class DataExtensions
    {
        public static IServiceCollection AddAppDbContext(
            this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment hostingEnvironment)
        {
            var connectionString = configuration.GetConnectionString("FinanceBuddyDb");
            services.AddDbContext<FinanceBuddyDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<FinanceBuddyDbContext>();
                db.Database.Migrate();
            }

            return host;
        }
    }
}
