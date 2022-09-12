using ECommerceApp.Core.DTO;
using ECommerceApp.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
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
                if(await _service.LoginAsync(dTO) == null)
                {
                    return BadRequest("Login failed");
                }
                return Accepted();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
