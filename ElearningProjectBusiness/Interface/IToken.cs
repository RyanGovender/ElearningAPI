using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectBusiness.Interface
{
    public interface IToken
    {
       Task<bool> AssignTokenToUser(string email,string refreshToken, int numberOfDaysToAdd);
       string GenerateJWTToken(List<Claim> claims);
       string GenerateRefreshToken();
       ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

    }
}
