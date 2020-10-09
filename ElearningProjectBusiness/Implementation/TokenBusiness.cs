using ElearningProjectBusiness.Interface;
using ElearningProjectRepository.Interface;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectBusiness.Implementation
{
    public class TokenBusiness : IToken
    {
        private const string _webAddress = "http://localhost:44355";
        private const int _expireTime = 1;
        private IDapperBase _dapperBase;
        public TokenBusiness(IDapperBase dapperBase)
        {
            _dapperBase = dapperBase;
        }

        public async Task<bool> AssignTokenToUser(string email, string refreshToken,int numberOfDaysToAdd)
        {
            var parameters = new { @Email = email, @RefreshToken = refreshToken, @RefreshTokenExpiryDate = DateTime.Now.AddDays(numberOfDaysToAdd) };
            var result = await _dapperBase.ExecuteQuery("sp_UpdateRefreshToken", parameters);
            return result;
        }

        public string GenerateJWTToken(List<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));// Create a get method to get key from a more safe location
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _webAddress,
                audience: _webAddress,
                claims:claims,
                expires: DateTime.Now.AddMinutes(_expireTime),
                signingCredentials: signinCredentials
            );
            var tokenString =  new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }

        public string GenerateRefreshToken()
        {
            var random = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(random);
            return Convert.ToBase64String(random);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345")),// remove this in the future
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken _securityToken);
            var jwtSecurityToken = _securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                 StringComparison.InvariantCultureIgnoreCase)) 
                throw new SecurityTokenException("Invalid token");

            return principal;

        }

       
    }
}
