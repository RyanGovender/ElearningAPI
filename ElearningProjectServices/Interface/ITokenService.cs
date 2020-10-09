using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectServices.Interface
{
    public interface ITokenService
    {
        string GenerateToken(List<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        Task<bool> AssignTokenToUser(string email, string refreshToken,int numberOfDaysToAdd);
    }
}
