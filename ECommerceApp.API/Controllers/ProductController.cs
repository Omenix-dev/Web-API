using AutoMapper;
using ECommerceApp.Core.Interface;
using ECommerceApp.Core.Utilities;
using ECommerceApp.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetProducts()
        {
            try
            {
                return Ok(_service.GetAllProductAsync());
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Try Again Later Please");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProduct(string id)
        {
            try
            {
               return Ok(await _service.GetProductByIdAsync(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Try Again Later Please");
            }
        }

    }
}
