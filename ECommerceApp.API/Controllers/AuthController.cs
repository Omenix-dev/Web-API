using ECommerceApp.Core.DTO;
using ECommerceApp.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IUnitOfWork _unit;

        public AuthController(IAuthService service, IUnitOfWork unit)
        {
            _service = service;
            _unit = unit;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDTO dTO)
        {
            return StatusCode(200,await _service.RegisterAsync(dTO));
        }
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dTO)
        {
            try
            {
                //HttpContext.User;
                if(!await _service.LoginAsync(dTO))
                {
                    return Unauthorized();
                }
               // var user = await _unit.UserRepository.GetAsync(user => user.Email.Equals(dTO.Email.ToLower()));
                return Accepted(new { Token = await _service.CreateToken()});
            }
            catch (Exception ex)
            {
                return Problem($"Something went wrong in the {nameof(Login)}, {ex.Message}, {ex.StackTrace}", statusCode: 500);
            }
        }
    }
}
