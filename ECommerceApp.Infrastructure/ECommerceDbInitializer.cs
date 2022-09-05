using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceApp.Infrastructure
{
    public class ECommerceDbInitializer
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using(var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ECommerceDbContext>();
            }
        }
    }
}
