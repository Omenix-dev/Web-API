using ECommerceApp.Domain.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace ECommerceApp.Infrastructure
{
    public class ECommerceDbInitializer
    {
        public static async Task Seed(IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();

            var context = serviceScope.ServiceProvider.GetService<ECommerceDbContext>();
            string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, @"ECommerceApp.Infrastructure\Data\");

            if (!context.Categories.Any())
            {
                var readText = await File.ReadAllTextAsync(filePath + "Categories.json");
                List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(readText);
                await context.Categories.AddRangeAsync(categories);
            }

            if (!context.Products.Any())
            {
                var readText = await File.ReadAllTextAsync( filePath+ "Products.json");
                List<Product> products =  JsonConvert.DeserializeObject<List<Product>>(readText);
                await context.Products.AddRangeAsync(products);
            }

            if (!context.Roles.Any())
            {
                var readText = await File.ReadAllTextAsync(filePath + "Roles.json");
                List<Role> roles = JsonConvert.DeserializeObject<List<Role>>(readText);
                await context.Roles.AddRangeAsync(roles);
            }
            await context.SaveChangesAsync();
        }
    }
}
