using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElearningProjectBusiness.Implementation.Global;
using ElearningProjectModels.Models;
using ElearningProjectRepository.Implementation;
using ElearningProjectServices.Interface;
using ElearningProjectServices.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElearningProjectAdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class LearningPathController : ControllerBase
    {
        private IUnitOfWorkService _unitOfWork;
        public LearningPathController(IUnitOfWorkService unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _unitOfWork.LearningPathService.GetAll();
            return result.Any() ? StatusCode(200, result) : StatusCode(400, result);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] LearningPath learningPath)
        {
            if (learningPath == null) return StatusCode(400,false);
            var result = await _unitOfWork.LearningPathService.Inset(learningPath);
            var status = ControllerService.GetIActionResult(result);// A switch statment that creates a status objected based on the result from the previous method.
            return StatusCode(status.StatusCode, status.Response);
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromBody] LearningPath learningPath)
        {
            if (learningPath == null) return StatusCode(400);
            var result = await _unitOfWork.LearningPathService.Update(learningPath);
            // Elastic.LogInformation(learningPath,learningPath);
            var status = ControllerService.GetIActionResult(result);// A switch statment that creates a status objected based on the result from the previous method.
            return StatusCode(status.StatusCode, status.Response);
        }

        //[HttpDelete]
        //[Route("Delete")]
        //public async Task<IActionResult> Delete(int?id)
        //{
        //    if (!id.HasValue) return StatusCode(400,false);
        //    var result = await _unitOfWork.LearningPathService.Delete(id);
        //    return result ? StatusCode(200, result) : StatusCode(404, result);
        //}

    }
}