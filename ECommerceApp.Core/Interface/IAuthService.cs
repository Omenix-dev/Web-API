using ECommerceApp.Core.DTO;
using ECommerceApp.Domain.Model;

namespace ECommerceApp.Core.Interface
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegistrationDTO userDetails);
        Task<User> LoginAsync(LoginDTO details);
    }
}