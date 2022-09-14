using AutoMapper;
using ECommerceApp.Core.DTO;
using ECommerceApp.Core.Interface;
using ECommerceApp.Core.Utilities;
using ECommerceApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Services
{
    public class AuthService : IAuthService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public AuthService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO<string>> RegisterAsync(RegistrationDTO userDetails)
        {
            var result = new ResponseDTO<string>();
            try
            {
                var checkEmail = await _unitOfWork.UserRepository.GetAsync(user => user.Email.Equals(userDetails.Email.ToLower()));
                if (checkEmail != null)
                {
                    result.Error = new List<ErrorItem>
                    {
                        new ErrorItem { Description = "" }
                    };
                    result.StatusCode = (int)HttpStatusCode.BadRequest;
                    return result;
                }

                /*
                 * CART ITEMS  ===>  LIST OF PRODUCT ITEMS 
                 * ORDER ====> ORDERID
                 * ORDER DETAILS
                 */
                var userModel = _mapper.Map<User>(userDetails);
                userModel.PasswordSalt = SaltHashAlgorithm.GenerateSalt();
                userModel.PasswordHash = SaltHashAlgorithm.GenerateHash(userDetails.Password, userModel.PasswordSalt);
                await _unitOfWork.UserRepository.InsertAsync(userModel);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await _unitOfWork.Save();
            }

            result.Status = true;
            result.Data = string.Empty;

            return result;
        }

        public async Task<User> LoginAsync(LoginDTO details)
        {
            var userData = await _unitOfWork.UserRepository.GetAsync(user => user.Email.Equals(details.Email.ToLower()));
            if (userData == null)
                return null;
            var isPassed = SaltHashAlgorithm.CompareHash(details.Password, userData.PasswordHash, userData.PasswordSalt);
            if (isPassed)
                return userData;
            else
                return null;
            
        }
    }
}
