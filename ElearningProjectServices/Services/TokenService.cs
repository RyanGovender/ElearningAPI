using ElearningProjectBusiness.Interface;
using ElearningProjectServices.Interface;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectServices.Services
{
    public class TokenService : ITokenService
    {
        private IUnitOfWorkBusiness _unitOfWorkBusiness;

        public TokenService(IUnitOfWorkBusiness unitOfWorkBusiness)
        {
            _unitOfWorkBusiness = unitOfWorkBusiness;
        }
        public string GenerateToken(List<Claim>claims)
        {
            return _unitOfWorkBusiness.Token.GenerateJWTToken(claims);
        }

        public string GenerateRefreshToken()
        {
            return _unitOfWorkBusiness.Token.GenerateRefreshToken();
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            return _unitOfWorkBusiness.Token.GetPrincipalFromExpiredToken(token);
        }

        public async Task<bool> AssignTokenToUser(string email, string refreshToken, int numberOfDaysToAdd)
        {
            return await _unitOfWorkBusiness.Token.AssignTokenToUser(email, refreshToken, numberOfDaysToAdd);
        }
    }
}
