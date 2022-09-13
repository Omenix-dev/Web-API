using ECommerceApp.Core.DTO;
using ECommerceApp.Domain.Model;

namespace ECommerceApp.Core.Interface
{
    public interface IProductService
    {
        ResponseDTO<PaginationResult<IEnumerable<ProductDTO>>> GetProductsByPaginationAsync(int pageSize, int pageNumber);
        Task<ResponseDTO<ProductDTO>> GetProductByIdAsync(string id);
        Task<bool> AddProductAsync(Product product);
    }
}