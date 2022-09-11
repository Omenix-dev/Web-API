using ECommerceApp.Domain.Model;

namespace ECommerceApp.Core.Interface
{
    public interface IProductService
    {
        IQueryable<Product> GetAllProductAsync();
        Task<Product> GetProductByIdAsync(string id);
        Task<bool> AddProductAsync(Product product);
    }
}