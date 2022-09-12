using ECommerceApp.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet("{id}/hello")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetOrdersById(string id)
        {
            try
            {
                return Ok(_service.GetOrdersByUserIdAsync(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Try Again Later Please");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetSuccessfulOrdersById(string id)
        {
            try
            {
                return Ok(_service.GetAllSuccessfullOrderAsync(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Try Again Later Please");
            }
        }
    }
}
