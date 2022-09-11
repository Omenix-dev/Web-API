using AutoMapper;
using ECommerceApp.Core.DTO;
using ECommerceApp.Core.Interface;
using ECommerceApp.Core.Utilities;
using ECommerceApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> RegisterAsync(RegistrationDTO userDetails)
        {
            try
            {
                var checkEmail = await _unitOfWork.UserRepository.GetAsync(user => user.Email.Equals(userDetails.Email.ToLower()));
                if (checkEmail != null)
                    return false;
                var userModel = _mapper.Map<User>(userDetails);
                await _unitOfWork.UserRepository.InsertAsync(userModel);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
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
