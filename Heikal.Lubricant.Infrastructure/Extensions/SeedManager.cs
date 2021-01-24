using Heikal.Lubricant.Infrastructure.Data;
using Heikal.Lubricant.Infrastructure.Seeds;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Heikal.Lubricant.Infrastructure.Extensions
{
    public static class SeedManager
    {
        public static IHost SeedDatabase(this IHost builder)
        {
            using (var scope = builder.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetService<LubricantContext>())
                {
                    DaySeed.DaysData(context);
                    RoleSeed.RolesData(context);
                    UserSeed.UsersData(context);
                    context.SaveChanges();
                }
            }
            return builder;
        }
    }
}
