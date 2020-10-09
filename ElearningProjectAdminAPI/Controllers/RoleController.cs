using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElearningProjectModels.Models;
using ElearningProjectServices.Interface;
using ElearningProjectServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using static ElearningProjectModels.Enum.Enum;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElearningProjectAdminAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class RoleController : Controller
    {
        private IUnitOfWorkService _unitOfWorkService;

        public RoleController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            var result = await _unitOfWorkService.RoleService.GetAll();//Create stored proc for this method.
            return result.Any() ? Ok(result) : Ok(null);
        }

       // [Authorize(Role="Admin")]
        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] Role role)
        {
            if (role is null || !ModelState.IsValid) return BadRequest(new { Message ="No data provided." , Code = 400});
            var result = await _unitOfWorkService.RoleService.Add(role);
            var status = ControllerService.GetIActionResult(result);// A switch statment that creates a status objected based on the result from the previous method.
            return StatusCode(status.StatusCode,status.Response);// eg.   Format -  StatusCode = 400 Response = {Message = "Some message", Code = 400};
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromBody] Role role)
        {
            if (role is null || !ModelState.IsValid) return BadRequest(new { Message = "No data provided.", Code = 400 });
            var result = await _unitOfWorkService.RoleService.Update(role);
            var status = ControllerService.GetIActionResult(result);// A switch statment that creates a status objected based on the result from the previous method.
            return StatusCode(status.StatusCode, status.Response); // eg.   Format -  StatusCode = 400 Response = {Message = "Some message", Code = 400};
        }

        [HttpPost]
        [Route("AssignUserRole")]
        public async Task<IActionResult> AssignUserRole([FromBody] UserRole userRole)
        {
            if (userRole is null || !ModelState.IsValid) return BadRequest(new { Message = "No data provided", Code =400 });
            var result = await _unitOfWorkService.RoleService.AssignUserRole(userRole);
            var status = ControllerService.GetIActionResult(result);
            return StatusCode(status.StatusCode, status.Response);
        }

        [HttpPut]
        [Route("UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UserRole userRole)
        {
            if (userRole is null || !ModelState.IsValid) return BadRequest(new { Message = "No data provided", Code = 400 });
            var result = await _unitOfWorkService.RoleService.UpdateUserRole(userRole);
            var status = ControllerService.GetIActionResult(result);
            return StatusCode(status.StatusCode, status.Response);
        }

    }
}
