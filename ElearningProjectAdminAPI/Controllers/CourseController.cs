using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElearningProjectModels.Models;
using ElearningProjectServices.Interface;
using ElearningProjectServices.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElearningProjectAdminAPI.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private IUnitOfWorkService _unitOfWorkService;
        public CourseController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] Course course)
        {
            if (course is null || !ModelState.IsValid) return BadRequest(new { Message = "No data provided.", Code = 400 });
            var result = await _unitOfWorkService.CourseService.Insert(course);
            var status = ControllerService.GetIActionResult(result);// A switch statment that creates a status objected based on the result from the previous method.
            return StatusCode(status.StatusCode, status.Response);// eg.   Format -  StatusCode = 400 Response = {Message = "Some message", Code = 400};
        }
    }
}
