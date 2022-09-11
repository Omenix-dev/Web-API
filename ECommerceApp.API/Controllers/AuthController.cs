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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
               if(!await _service.RegisterAsync(dTO))
                {
                    return BadRequest("User Registration Attempt Failed");
                }
                return Ok(await _service.RegisterAsync(dTO));
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal Server Error. Try Again Later Please");
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] RegistrationDTO dTO)
        {
            throw new NotImplementedException();
        }
    }
}
