using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ElearningProjectAdminAPI.Extentions;
using ElearningProjectModels.Models;
using ElearningProjectServices.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static ElearningProjectModels.Enum.Enum;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElearningProjectAdminAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class AuthController : Controller
    {
        private IUnitOfWorkService _unitOfWorkService;
        public AuthController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        //add lockout
        [HttpPost,Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login user)
        {
            if (user == null) return BadRequest();

            var result = await _unitOfWorkService.AccountService.Login(user.Email, user.PasswordHash);
            switch(result)
            {
                case LoginStatus.Failed:
                    return Unauthorized(new { message = "Ensure all required fields are filled." });

                case LoginStatus.Successful:
                    var token = _unitOfWorkService.TokenService.GenerateToken(_unitOfWorkService.RoleService.GetClaimsForJWT(user.Email));
                    var resfreshToken = _unitOfWorkService.TokenService.GenerateRefreshToken();
                    await _unitOfWorkService.TokenService.AssignTokenToUser(user.Email,resfreshToken,7);
                    return StatusCode(200,new { message = "Login Successful.", Token = token, RefreshToken = resfreshToken, Code = 200 });

                case LoginStatus.Unsuccessful:
                    return Unauthorized(new { message="Incorrect Email or Password", Code = 401});

                default:
                    return Unauthorized(new { message = "Login Falied", Code = 401 });
            }

        }

    }
}
