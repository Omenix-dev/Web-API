using ECommerceApp.Core.Interface;
using ECommerceApp.Domain.Model;
using ECommerceApp.Core.Utilities;
using AutoMapper;
using ECommerceApp.Core.DTO;
using System.Net;

namespace ECommerceApp.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public ResponseDTO<PaginationResult<IEnumerable<ProductDTO>>> GetProductsByPaginationAsync(int pageSize, int pageNumber)
        {
            var responseDto = new ResponseDTO<PaginationResult<IEnumerable<ProductDTO>>>();
            try
            {
                var exec = _unitOfWork.ProductRepository.GetAllAsync();
                var response = Paginator.PaginationAsync<Product,ProductDTO>(exec,pageSize,pageNumber,_mapper);
                responseDto.Data = response;
                responseDto.StatusCode = response != null ? (int)HttpStatusCode.Accepted : (int)HttpStatusCode.NoContent;
                responseDto.Status = true;
                responseDto.Message = response != null ? "Resquest is Successfull" : "the database is Empty";
                return responseDto;
            }
            catch (Exception Ex)
            {
                responseDto.Data =null;
                responseDto.StatusCode = (int)HttpStatusCode.BadRequest;
                responseDto.Status = false;
                responseDto.Message = "Resquest was unSuccessfull";
                responseDto.Error.Add(new ErrorItem() {InnerException = Ex.Message });
                return responseDto;
            }
        }

        public async Task<ResponseDTO<ProductDTO>> GetProductByIdAsync(string id)
        {
            var responseDto = new ResponseDTO<ProductDTO>();
            try
            {
                var exec = _unitOfWork.ProductRepository.GetAllAsync();
                var response =await _unitOfWork.ProductRepository.GetAsync(product => product.Id.Equals(id));
                responseDto.Data = _mapper.Map<ProductDTO>(response);
                responseDto.StatusCode = response != null ? (int)HttpStatusCode.Accepted : (int)HttpStatusCode.NoContent;
                responseDto.Status = response != null ? true : false;
                responseDto.Message = response != null ? "Resquest is Successfull" : "Instance doesn't exist in the Entity";
                return responseDto;
            }
            catch (Exception Ex)
            {
                responseDto.Data = null;
                responseDto.StatusCode = (int)HttpStatusCode.BadRequest;
                responseDto.Status = false;
                responseDto.Message = "Resquest was unSuccessfull";
                responseDto.Error.Add(new ErrorItem() { InnerException = Ex.Message });
                return responseDto;
            }
             
        }
        public Task<bool> AddProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
