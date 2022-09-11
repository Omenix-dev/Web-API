using ECommerceApp.Core.DTO;
using ECommerceApp.Domain.Model;

namespace ECommerceApp.Core.Interface
{
    public interface IAuthService
    {
        Task<User> LoginAsync(LoginDTO details);
        Task<bool> RegisterAsync(RegistrationDTO userDetails);
    }
}