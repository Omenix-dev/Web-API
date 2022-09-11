using ECommerceApp.Core.Interface;
using ECommerceApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<Product> GetAllProductAsync()
        {
            return _unitOfWork.ProductRepository.GetAllAsync();
        }

        public Task<Product> GetProductByIdAsync(string id)
        {
            return _unitOfWork.ProductRepository.GetAsync(product => product.Id.Equals(id));
        }
        public Task<bool> AddProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
