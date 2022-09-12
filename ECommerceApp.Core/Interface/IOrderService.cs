using ECommerceApp.Core.DTO;
using ECommerceApp.Domain.Model;

namespace ECommerceApp.Core.Interface
{
    public interface IOrderService
    {
        bool AddOrderAsync(List<OrderDetailsDTO> orderDetails, string userId);
        bool DeleteOrderById(string orderId);
        bool DeleteOrderDetailsAsync(string orderDetailsId);
        IQueryable<Order> GetAllSuccessfullOrderAsync(string UserId);
        IEnumerable<Order> GetOrdersByUserIdAsync(string UserId);
    }
}