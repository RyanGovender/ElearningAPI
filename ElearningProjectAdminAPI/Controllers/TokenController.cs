using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElearningProjectModels.ViewModels;
using ElearningProjectServices.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElearningProjectAdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private IUnitOfWorkService _unitOfWorkService;
        public TokenController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh(TokenModelApi tokenModelApi)
        {
            if (tokenModelApi is null) return BadRequest(new { Message = "Invalid Client Request" });

            var principal = _unitOfWorkService.TokenService.GetPrincipalFromExpiredToken(tokenModelApi.AccessToken);
            var user = await _unitOfWorkService.UserService.GetUserByUsername(principal.Identity.Name);
            
            if (user is null || user.RefreshToken != tokenModelApi.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                return BadRequest(new { Message = "Invalid Client Request" });
          
            var newAccessToken = _unitOfWorkService.TokenService.GenerateToken(_unitOfWorkService.RoleService.GetClaimsForJWT(user.Email));
            var newRefreshToken = _unitOfWorkService.TokenService.GenerateRefreshToken();

            await _unitOfWorkService.TokenService.AssignTokenToUser(principal.Identity.Name, newRefreshToken,0);

            return new ObjectResult(new
            {
                accessToken = newAccessToken,
                refreshToken = newRefreshToken
            });

        }

        [HttpPost, Authorize]
        [Route("revoke")]
        public async Task<IActionResult> Revoke()
        {
            var user = User.Identity.Name;
            if (user is null) return BadRequest();
            await _unitOfWorkService.TokenService.AssignTokenToUser(user,null,0);
            return NoContent();
        }
    }
}
