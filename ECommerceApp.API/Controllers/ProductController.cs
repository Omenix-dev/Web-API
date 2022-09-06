using ECommerceApp.Core.Interface;
using ECommerceApp.Core.Utilities;
using ECommerceApp.Domain.Model;
using ECommerceApp.Infrastructure;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ECommerceDbContext context;
        private readonly IRepository<Product> _repo;
        public ProductController(ECommerceDbContext context, IRepository<Product> repo)
        {
            this.context = context;
            _repo = repo;   
        }
        [HttpGet("{page")]
        public async Task<ActionResult> GetProducts(int page)
        {
            var products = await _repo.GetAllAsync();
            if (products == null) { return NotFound(); }

            var pageResults = 10f;
            var pageCount = Math.Ceiling(products.Count() / pageResults);
            var productItems = products.Skip((page - 1) * (int)pageResults).Take((int)pageResults).AsQueryable();

            var response = new ProductResponse
            {
                Products = productItems,
                CurrentPage = page,
                Pages = (int)pageCount,
            };
            return Ok(productItems);
        }

    }
}
