using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElearningProjectModels.Models;
using ElearningProjectServices.Interface;
using System.IdentityModel.Tokens;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElearningProjectAdminAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUnitOfWorkService _unitOfWorkService;
        public UsersController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        
       // [Authorize]
        [HttpGet, Authorize(Roles ="Admin")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result =await  _unitOfWorkService.UserService.GetAll();
                var email = User;
                return result.Any() ? StatusCode(200, result) : StatusCode(400, result); 
            }
            catch (Exception)
            {
                return StatusCode(400, false); // check why you used false. Use proper error message.
            }
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromBody] User user) // again error handling
        {
            try
            {
                if (user == null) return StatusCode(400);
                var result = await _unitOfWorkService.UserService.Update(user);
                return result ? StatusCode(200, result) : StatusCode(400, result);
            }
            catch (Exception)
            {
                return StatusCode(400, false);
            }
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] User user) // again error handling
        {
            try
            {
                if (user == null) return StatusCode(400);
                var result = await _unitOfWorkService.UserService.Inset(user);
                return result ? StatusCode(200, result) : StatusCode(400, result);
            }
            catch (Exception)
            {
                return StatusCode(400, false);
            }
        }


    }
}
